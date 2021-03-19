mergeInto(LibraryManager.library, {

    $js_gamesave_db: {},

    js_gamesave_init__deps: ['$js_gamesave_db'],
    js_gamesave_init__proxy: 'async',
    js_gamesave_init__sig: 'v',
    js_gamesave_init : function () {
        // Get access to the IndexedDB APIs.
        var indexedDB = window.indexedDB || window.webkitIndexedDB || window.mozIndexedDB || window.msIndexedDB;
        var dbVersion = 1;

        js_gamesave_db.dbName = "UnityGameSaveDatabase";
        js_gamesave_db.dbObjectStoreName = "UnityGameSaveObjectStore";
        js_gamesave_db.gameSaveDataReads = {};

        var request = indexedDB.open(js_gamesave_db.dbName, dbVersion);
        request.onsuccess = function(evt) {
            js_gamesave_db.db = request.result;
        };

        request.onupgradeneeded = function (evt) {
            js_gamesave_db.db = evt.currentTarget.result;
            js_gamesave_db.db.createObjectStore(js_gamesave_db.dbObjectStoreName, { keyPath: "name" });
        };
    },

    js_gamesave_writeToDisk__deps: ['$js_gamesave_db'],
    js_gamesave_writeToDisk__proxy: 'async',
    js_gamesave_writeToDisk__sig: 'iiii',
    js_gamesave_writeToDisk : function (gameSaveName, buffer, bufferLength) {
        // gameSaveName is a non-zero length string. This is checked in the GameSaveSystem.
        gameSaveName = UTF8ToString(gameSaveName);

        if (!js_gamesave_db.db) {
            console.warn('GameSave write to disk failed because the IndexedDB is not initialized. Game save name = ' + gameSaveName);
            return 0;
        } 

        if (!buffer || (bufferLength <= 0)) {
            console.warn('GameSave write to disk failed because there is no game save data. Game save name = ' + gameSaveName);
            return 0;
        }

        // Convert the passed-in buffer to a Uint8Array, which can be saved in IndexedDB.
        var uint8Buffer = new Uint8Array(bufferLength);
        for (var i = 0; i < bufferLength; i++)
            uint8Buffer[i] = HEAPU8[buffer+i];

        var gameSaveData = { name: gameSaveName, buffer: uint8Buffer };

        var transaction = js_gamesave_db.db.transaction(js_gamesave_db.dbObjectStoreName, "readwrite");
        var objectStore = transaction.objectStore(js_gamesave_db.dbObjectStoreName);    
        objectStore.delete(gameSaveName);
        objectStore.add(gameSaveData);
        return 1;
    },

    js_gamesave_asyncReadFromDisk__deps: ['$js_gamesave_db'],
    js_gamesave_asyncReadFromDisk__proxy: 'async',
    js_gamesave_asyncReadFromDisk__sig: 'ii',
    js_gamesave_asyncReadFromDisk : function (gameSaveName) {
        // gameSaveName is a non-zero length string. This is checked in the GameSaveSystem.
        gameSaveName = UTF8ToString(gameSaveName);

        if (!js_gamesave_db.db) {
            console.warn('GameSave read from disk failed because the IndexedDB is not initialized. Game save name = ' + gameSaveName);
            return 0;
        }

        // If a previous asyncReadFromDisk was executed, but pullCompletedReadBuffer was never called as a follow-up, then we need to clean that up here.
        delete js_gamesave_db.gameSaveDataReads[gameSaveName];
        
        var transaction = js_gamesave_db.db.transaction(js_gamesave_db.dbObjectStoreName, "readwrite");
        var objectStore = transaction.objectStore(js_gamesave_db.dbObjectStoreName);
        var objectStoreRequest = objectStore.get(gameSaveName);

        objectStoreRequest.onsuccess = function(objectStoreEvt) {
            if (objectStoreRequest.result) {
                js_gamesave_db.gameSaveDataReads[gameSaveName] = objectStoreRequest.result;
            }
            else {
                var gameSaveData = { name: gameSaveName, buffer: null };
                js_gamesave_db.gameSaveDataReads[gameSaveName] = gameSaveData;
                console.warn('GameSave read from disk failed. Game save name = ' + gameSaveName);
            }
        };

        objectStoreRequest.onerror = function(objectStoreEvt) {
            var gameSaveData = { name: gameSaveName, buffer: null };
            js_gamesave_db.gameSaveDataReads[gameSaveName] = gameSaveData;
            console.warn('GameSave read from disk failed. Game save name = ' + gameSaveName);
        };

        return 1;
    },

    js_gamesave_getLength__deps: ['$js_gamesave_db'],
    js_gamesave_getLength__proxy: 'sync',
    js_gamesave_getLength__sig: 'iii',
    js_gamesave_getLength : function (gameSaveName, length) {
        gameSaveName = UTF8ToString(gameSaveName);
        if (js_gamesave_db.gameSaveDataReads[gameSaveName]) {
            // If the read succeeded, set the buffer length and return success. Otherwise, there was an error of some kind because the read completed
            // but returned no data.
            if (js_gamesave_db.gameSaveDataReads[gameSaveName].buffer) {
                HEAP32[length>>2] = js_gamesave_db.gameSaveDataReads[gameSaveName].buffer.length;
            }
            else {
                return 0;
            }
        }
        else
        {
            // The read hasn't completed, so return buffer length zero for now, but return success.
            HEAP32[length>>2] = 0;
        }

        return 1;
    },

    js_gamesave_getBuffer__deps: ['$js_gamesave_db'],
    js_gamesave_getBuffer__proxy: 'sync',
    js_gamesave_getBuffer__sig: 'iiii',
    js_gamesave_pullCompletedReadBuffer : function (gameSaveName, buffer, bufferLength) {
        var result = 0;

        gameSaveName = UTF8ToString(gameSaveName);
        if (js_gamesave_db.gameSaveDataReads[gameSaveName]) {
            var uint8Buffer = js_gamesave_db.gameSaveDataReads[gameSaveName].buffer;

            // Convert the JS UInt8Array to a buffer that can be consumed in C#.
            if (js_gamesave_db.gameSaveDataReads[gameSaveName].buffer && buffer && (bufferLength == uint8Buffer.length)) {
                HEAPU8.set(uint8Buffer, buffer);
                result = 1;
            }

            delete js_gamesave_db.gameSaveDataReads[gameSaveName];
        }

        return result;
    },
});
