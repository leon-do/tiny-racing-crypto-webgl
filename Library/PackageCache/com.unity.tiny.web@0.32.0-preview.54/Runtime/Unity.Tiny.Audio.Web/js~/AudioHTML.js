mergeInto(LibraryManager.library, {

    js_html_initAudio__sig: 'i',
    js_html_initAudio__proxy: 'sync',
    js_html_initAudio : function() {
        
        ut = ut || {};
        ut._HTML = ut._HTML || {};

        ut._HTML.audio_setGain = function(sourceNode, volume) {
            sourceNode.gainNode.gain.value = volume;
        };
        
        ut._HTML.audio_setPan = function(sourceNode, pan) {
            sourceNode.panNode.setPosition(pan, 0, 1 - Math.abs(pan));
        };

        ut._HTML.audio_isSafari = function() {
            var isChrome = window.navigator.userAgent.indexOf("Chrome") > -1;
            var isSafari = !isChrome && (window.navigator.userAgent.indexOf("Safari") > -1);
            return isSafari;
        };

        this.unlockState = 0/*locked*/;

        ut._HTML.unlock = function() {
            if (self.unlockState == 0)
                return;

            // call this method on touch start to create and play a buffer, then check
            // if the audio actually played to determine if audio has now been
            // unlocked on iOS, Android, etc.
            if (!self.audioContext || self.unlockState == 2/*unlocked*/)
                return;

            function unlocked() {
                // update the unlocked state and prevent this check from happening
                // again
                self.unlockState = 2/*unlocked*/;
                delete self.unlockBuffer;
                //console.log("[Audio] unlocked");

                // remove the touch start listener
                document.removeEventListener('click', ut._HTML.unlock, true);
                document.removeEventListener('touchstart', ut._HTML.unlock, true);
                document.removeEventListener('touchend', ut._HTML.unlock, true);
                document.removeEventListener('keydown', ut._HTML.unlock, true);
                document.removeEventListener('keyup', ut._HTML.unlock, true);
            }

            // If AudioContext is already enabled, no need to unlock again
            if (self.audioContext.state === 'running') {
                unlocked();
                return;
            }

            // fix Android can not play in suspend state
            if (self.audioContext.resume) self.audioContext.resume();

            // create an empty buffer for unlocking
            if (!self.unlockBuffer) {
                self.unlockBuffer = self.audioContext.createBuffer(1, 1, 22050);
            }

            // and a source for the empty buffer
            var source = self.audioContext.createBufferSource();
            source.buffer = self.unlockBuffer;
            source.connect(self.audioContext.destination);

            // play the empty buffer
            if (typeof source.start === 'undefined') {
                source.noteOn(0);
            } else {
                source.start(0);
            }

            // calling resume() on a stack initiated by user gesture is what
            // actually unlocks the audio on Android Chrome >= 55
            if (self.audioContext.resume) self.audioContext.resume();

            // setup a timeout to check that we are unlocked on the next event
            // loop
            source.onended = function () {
                source.disconnect(0);
                unlocked();
            };
        };

        // audio initialization
        if (!window.AudioContext && !window.webkitAudioContext)
            return false;

        var audioContext =
            new (window.AudioContext || window.webkitAudioContext)();
        if (!audioContext)
            return false;
        audioContext.listener.setPosition(0, 0, 0);

        this.audioContext = audioContext;
        this.audioClips = {};
        this.audioSources = {};
        this.compressedAudioBufferBytes = 0;
        this.uncompressedAudioBufferBytes = 0;
        this.uncompressedAudioBufferBytesMax = 50*1024*1024;

        var navigator = (typeof window !== 'undefined' && window.navigator)
            ? window.navigator
            : null;
        var isMobile = /iPhone|iPad|iPod|Android|BlackBerry|BB10|Silk|Mobi/i.test(
            navigator && navigator.userAgent);
        var isTouch = !!(isMobile ||
            (navigator && navigator.maxTouchPoints > 0) ||
            (navigator && navigator.msMaxTouchPoints > 0));
        var isMobileSafari = isMobile && ut._HTML.audio_isSafari();

        if (this.audioContext.state !== 'running' || isMobile || isTouch) {
            ut._HTML.unlock();
        } else {
            this.unlockState = 2/*unlocked*/;
        }

        if (!isMobileSafari)
        {
            document.addEventListener('visibilitychange', function() {
                if ((document.visibilityState === 'visible') && audioContext.resume)
                    audioContext.resume();
                else if ((document.visibilityState !== 'visible') && audioContext.suspend)
                    audioContext.suspend();
            }, true);
        }

        //console.log("[Audio] initialized " + (["locked", "unlocking", "unlocked"][this.unlockState]));
        return true;
    },

    js_html_audioIsUnlocked__proxy: 'sync',
    js_html_audioIsUnlocked__sig: 'i',
    js_html_audioIsUnlocked : function() {
        return this.unlockState == 2/*unlocked*/;
    },

    // unlock audio for browsers
    js_html_audioUnlock__proxy: 'async',
    js_html_audioUnlock__sig: 'v',
    js_html_audioUnlock : function () {
        var self = this;
        if (self.unlockState >= 1/*unlocking or unlocked*/ || !self.audioContext ||
            typeof self.audioContext.resume !== 'function')
            return;

        // setup a touch start listener to attempt an unlock in
        document.addEventListener('click', ut._HTML.unlock, true);
        document.addEventListener('touchstart', ut._HTML.unlock, true);
        document.addEventListener('touchend', ut._HTML.unlock, true);
        document.addEventListener('keydown', ut._HTML.unlock, true);
        document.addEventListener('keyup', ut._HTML.unlock, true);
        // Record that we are now in the unlocking attempt stage so that the above event listeners
        // will not be attempted to be registered again.
        self.unlockState = 1/*unlocking*/;
    },

    // pause audio context
    js_html_audioPause__proxy: 'async',
    js_html_audioPause__sig: 'v',
    js_html_audioPause : function () {
        if (this.audioContext && this.audioContext.suspend && (this.audioContext.state === 'running')) {
            this.audioContext.suspend();
        }
    },

    // resume audio context
    js_html_audioResume__proxy: 'async',
    js_html_audioResume__sig: 'v',
    js_html_audioResume : function () {
        if (this.audioContext && this.audioContext.resume && (this.audioContext.state !== 'running')) {
            this.audioContext.resume();
        }
    },

    js_html_setMaxUncompressedAudioBufferBytes__proxy: 'async',
    js_html_setMaxUncompressedAudioBufferBytes__sig: 'vi',
    js_html_setMaxUncompressedAudioBufferBytes : function (maxUncompressedAudioBufferBytes) {
        this.uncompressedAudioBufferBytesMax = uncompressedAudioBufferBytesMax;
    },

    js_html_audioUpdate__proxy: 'sync',
    js_html_audioUpdate__sig: 'v',
    js_html_audioUpdate : function() {
        // To truly implement least-recently played, we would walk the list of sounds once for each sound we unload. Instead, to be more
        // efficient CPU-wise, we will just walk the list twice. 

        // Pass #1. Unload all sounds that have not been playing in notRecentlyUsedRefCount frames (a long time). In addition, on this first pass,
        // we'll also unload any really large sounds that aren't currently playing.
        var notRecentlyPlayedSeconds = 15.0;
        var largeAudioAssetSize = 4*1024*1024;
        var currentTime = this.audioContext.currentTime;
        for (var audioClipIdx in this.audioClips) {
            if (this.uncompressedAudioBufferBytes <= this.uncompressedAudioBufferBytesMax)
                break;

            var audioClip = this.audioClips[audioClipIdx];
            if (audioClip && (audioClip.loadingStatus == 3/*uncompressed loaded*/))
            {
                var notPlaying = audioClip.refCount <= 0;
                var notRecentlyPlayed = (currentTime - audioClip.lastPlayedTime >= notRecentlyPlayedSeconds);
                var uncompressedAudioBufferSize = audioClip.uncompressedAudioBuffer.length * audioClip.uncompressedAudioBuffer.numberOfChannels * 4;
                var largeAudioAsset = uncompressedAudioBufferSize >= largeAudioAssetSize;

                if (notPlaying && (notRecentlyPlayed || largeAudioAsset)) {   
                    this.uncompressedAudioBufferBytes -= uncompressedAudioBufferSize;
                    audioClip.loadingStatus = 1/*compressed loaded*/;
                    audioClip.refCount = 0;
                    audioClip.uncompressedAudioBuffer = null;
                    //console.log("Unloading clip " + audioClipIdx);
                }
            }
        }

        // Pass #2. Unload any unused sounds until we get down to our audio memory budget (uncompressedAudioBufferBytesMax).
        for (var audioClipIdx in this.audioClips) {
            if (this.uncompressedAudioBufferBytes <= this.uncompressedAudioBufferBytesMax)
                break;

            var audioClip = this.audioClips[audioClipIdx];
            if (audioClip && (audioClip.loadingStatus == 3/*uncompressed loaded*/) && (audioClip.refCount <= 0))
            {
                var uncompressedAudioBufferSize = audioClip.uncompressedAudioBuffer.length * audioClip.uncompressedAudioBuffer.numberOfChannels * 4;

                this.uncompressedAudioBufferBytes -= uncompressedAudioBufferSize;
                audioClip.loadingStatus = 1/*compressed loaded*/;
                audioClip.refCount = 0;
                audioClip.uncompressedAudioBuffer = null;
                //console.log("Unloading clip " + audioClipIdx);
            }
        }
    },

    // load audio clip
    js_html_audioStartLoadFile__proxy: 'sync',
    js_html_audioStartLoadFile__sig: 'iii',
    js_html_audioStartLoadFile : function (audioClipName, audioClipIdx) 
    {
        if (!this.audioContext || audioClipIdx < 0)
            return -1;

        audioClipName = UTF8ToString(audioClipName);

        var url = audioClipName;
        if (url.substring(0, 9) === "ut-asset:")
            url = UT_ASSETS[url.substring(9)];

#if SINGLE_FILE
        this.audioClips[audioClipIdx] = {
            url: url,
            loadingStatus: 4/*error*/,
        };
        var asset = SINGLE_FILE_ASSETS[url];
        if (asset) {
            this.audioClips[audioClipIdx].loadingStatus = 1;/*loaded compressed*/
            this.audioClips[audioClipIdx].compressedAudioBuffer = base64Decode(asset).buffer;
        }
#else
        var self = this;
        var request = new XMLHttpRequest();

        self.audioClips[audioClipIdx] = {
            loadingStatus: 0/*loading compressed*/,
            url: url
        };
        
        //console.log("Start loading clip " + audioClipIdx);
        request.open('GET', url, true);
        request.responseType = 'arraybuffer';
        request.onload =
            function () {
                self.audioClips[audioClipIdx].loadingStatus = 1/*loaded compressed*/;
                self.audioClips[audioClipIdx].compressedAudioBuffer = request.response;
                //console.log("Loaded clip " + audioClipIdx);
            };
        request.onerror =
            function () {
                self.audioClips[audioClipIdx].loadingStatus = 4/*error*/;
            };

        try {
            request.send();
        } catch (e) {
            // LG Nexus 5 + Android OS 4.4.0 + Google Chrome 30.0.1599.105 browser
            // odd behavior: If loading from base64-encoded data URI and the
            // format is unsupported, request.send() will immediately throw and
            // not raise the failure at .onerror() handler. Therefore catch
            // failures also eagerly from .send() above.
            self.audioClips[audioClipIdx].loadingStatus = 4/*error*/;
        }
#endif

        return audioClipIdx;
    },

    js_html_audioCheckLoad__proxy: 'sync',
    js_html_audioCheckLoad__sig: 'vi',
    js_html_audioCheckLoad : function (audioClipIdx) {
        var WORKING_ON_IT = 0;
        var SUCCESS = 1;
        var FAILED = 2;

        if (!this.audioContext || (audioClipIdx < 0) || (this.audioClips[audioClipIdx].loadingStatus == 4))
            return FAILED;        
        if (this.audioClips[audioClipIdx].loadingStatus == 0/*loading compressed*/)
            return WORKING_ON_IT;  

        return SUCCESS;
    },

    js_html_audioFree__proxy: 'sync',
    js_html_audioFree__sig: 'vi',
    js_html_audioFree : function (audioClipIdx) {
        if (!this.audioContext || audioClipIdx < 0)
            return;

        var audioClip = this.audioClips[audioClipIdx];
        if (!audioClip || (audioClip.loadingStatus == 4/*error*/))
            return;

        // If the audio clip is still being played, then stop it.
        if (audioClip.refCount > 0) {
            for (var audioSourceIdx in this.audioSources) {
                var sourceNode = this.audioSources[audioSourceIdx];
                if (sourceNode && sourceNode.buffer === audioClip.uncompressedAudioBuffer)
                    sourceNode.stop();
            }
        }

        if (audioClip.loadingStatus == 3/*uncompressed loaded*/) {
            var uncompressedAudioBufferSize = audioClip.uncompressedAudioBuffer.length * audioClip.uncompressedAudioBuffer.numberOfChannels * 4;
            this.uncompressedAudioBufferBytes -= uncompressedAudioBufferSize;
            audioClip.refCount = 0;
            audioClip.uncompressedAudioBuffer = null;
        }

        if (audioClip.compressedAudioBuffer) {
            audioClip.compressedAudioBuffer = null;
        }

        delete this.audioClips[audioClipIdx];
    },

    // get audio memory footprint
    js_html_getRequiredMemoryCompressed : function (audioClipIdx)
	{
        if (!this.audioContext || audioClipIdx < 0)
            return 0;

        var audioClip = this.audioClips[audioClipIdx];
        if (!audioClip || (audioClip.loadingStatus == 4/*error*/))
            return 0;

		if (!audioClip.compressedAudioBuffer)
			return 0;

		return audioClip.compressedAudioBuffer.byteLength;
	},

    js_html_getRequiredMemoryUncompressed : function (audioClipIdx)
	{
        if (!this.audioContext || audioClipIdx < 0)
            return 0;

        var audioClip = this.audioClips[audioClipIdx];
        if (!audioClip || (audioClip.loadingStatus == 4/*error*/))
            return 0;

		if (!audioClip.uncompressedAudioBuffer)
			return 0;

		return audioClip.uncompressedAudioBuffer.length * audioClip.uncompressedAudioBuffer.numberOfChannels * 4;
	},

    // create audio source node
    js_html_audioPlay__proxy: 'sync',
    js_html_audioPlay__sig: 'iiiiiii',
    js_html_audioPlay : function (audioClipIdx, audioSourceIdx, volume, pitch, pan, loop) 
    {
        if (!this.audioContext || audioClipIdx < 0 || audioSourceIdx < 0)
            return 0;

        if (this.audioContext.state !== 'running')
            return 0;

        var self = this;

        // require compressed audio buffer to be loaded
        var audioClip = this.audioClips[audioClipIdx];
        if (!audioClip || (audioClip.loadingStatus == 4/*error*/))
            return 0;

        if (audioClip.loadingStatus == 1/*compressed loaded*/) {
            audioClip.loadingStatus = 2/*decompressing*/;

            //console.log("Decompressing clip " + audioClipIdx);

            // Make a copy of the compressed audio data first. We aren't allowed to reuse the buffer we pass in since it will be handled asynchronously
            // on a different thread, even though we know we are only reading from it repeatedly.
            var audioBufferCompressedCopy = audioClip.compressedAudioBuffer.slice(0);

            var decodeStartTime = performance.now();
            self.audioContext.decodeAudioData(audioBufferCompressedCopy, function (buffer) {
                //console.log("Decompressed clip " + audioClipIdx);

                audioClip.loadingStatus = 3/*uncompressed loaded*/;
                audioClip.uncompressedAudioBuffer = buffer;
                audioClip.refCount = 0;
                audioClip.lastPlayedTime = self.audioContext.currentTime;
                self.uncompressedAudioBufferBytes += buffer.length * buffer.numberOfChannels * 4;

                var decodeDurationMsecs = performance.now() - decodeStartTime;
                var uncompressedSizeBytes = buffer.length * buffer.numberOfChannels * 4/*sizeof(float)*/;
                if (uncompressedSizeBytes > 50*1024*1024 || decodeDurationMsecs > 250) {
                    console.warn('Decompression of audio clip ' + self.audioClips[audioClipIdx].url + ' caused a playback delay of ' + decodeDurationMsecs + ' msecs, and resulted in an uncompressed audio buffer size of ' + uncompressedSizeBytes + ' bytes!');
                }
            });
        }

        if (audioClip.loadingStatus != 3)
            return 0;

        //console.log("Playing clip " + audioClipIdx);

        // create audio source node
        var sourceNode = this.audioContext.createBufferSource();
        sourceNode.buffer = audioClip.uncompressedAudioBuffer;
        sourceNode.playbackRate.value = pitch;

        var panNode = this.audioContext.createPanner();
        panNode.panningModel = 'equalpower';
        sourceNode.panNode = panNode;

        var gainNode = this.audioContext.createGain();
        gainNode.buffer = audioClip.uncompressedAudioBuffer;
        sourceNode.gainNode = gainNode;

        sourceNode.connect(gainNode);
        sourceNode.gainNode.connect(panNode);
        sourceNode.panNode.connect(this.audioContext.destination);

        ut._HTML.audio_setGain(sourceNode, volume);
        ut._HTML.audio_setPan(sourceNode, pan);

        // loop value
        sourceNode.loop = loop;

        if (this.audioSources[audioSourceIdx])
            // stop audio source node if it is already playing
            this.audioSources[audioSourceIdx].stop();
            
        // store audio source node
        this.audioSources[audioSourceIdx] = sourceNode;
        
        // on ended event
        sourceNode.onended = function (event) {
            sourceNode.isPlaying = false;

            sourceNode.gainNode.disconnect();
            sourceNode.panNode.disconnect();
            sourceNode.disconnect();

            delete sourceNode.buffer;

             if (self.audioSources[audioSourceIdx] === sourceNode)
                delete self.audioSources[audioSourceIdx];

            audioClip.refCount--;
            audioClip.lastPlayedTime = self.audioContext.currentTime;
        };

        // play audio source
        audioClip.lastPlayedTime = self.audioContext.currentTime;
        if (audioClip.refCount >= 1)
            audioClip.refCount++;
        else
            audioClip.refCount = 1;

        sourceNode.start();
        sourceNode.isPlaying = true;

        return 1;
    },

    // remove audio source node, optionally stop it 
    js_html_audioStop__proxy: 'sync',
    js_html_audioStop__sig: 'vii',
    js_html_audioStop : function (audioSourceIdx, dostop) {
        if (!this.audioContext || audioSourceIdx < 0)
            return 0;

        // retrieve audio source node
        var sourceNode = this.audioSources[audioSourceIdx];
        if (!sourceNode)
            return 0;

        // stop audio source
        if (sourceNode.isPlaying && dostop) {
            sourceNode.stop();
            sourceNode.isPlaying = false;
        }

        return 1;
    },

    js_html_audioSetVolume__proxy: 'sync',
    js_html_audioSetVolume__sig: 'iii',
    js_html_audioSetVolume : function (audioSourceIdx, volume) {
        if (!this.audioContext || audioSourceIdx < 0)
            return false;

        // retrieve audio source node
        var sourceNode = this.audioSources[audioSourceIdx];
        if (!sourceNode)
            return false;

        ut._HTML.audio_setGain(sourceNode, volume);
        return true;
    },
    
    js_html_audioSetPan__proxy: 'sync',
    js_html_audioSetPan__sig: 'iii',
    js_html_audioSetPan : function (audioSourceIdx, pan) {
        if (!this.audioContext || audioSourceIdx < 0)
            return false;

        // retrieve audio source node
        var sourceNode = this.audioSources[audioSourceIdx];
        if (!sourceNode)
            return false;

        ut._HTML.audio_setPan(sourceNode, pan);
        return true;
    },

    js_html_audioSetPitch__proxy: 'sync',
    js_html_audioSetPitch__sig: 'iii',
    js_html_audioSetPitch : function (audioSourceIdx, pitch) {
        if (!this.audioContext || audioSourceIdx < 0)
            return false;

        // retrieve audio source node
        var sourceNode = this.audioSources[audioSourceIdx];
        if (!sourceNode)
            return false;

        sourceNode.playbackRate.value = pitch;
        return true;
    },

    js_html_audioIsPlaying__proxy: 'sync',
    js_html_audioIsPlaying__sig: 'ii',
    js_html_audioIsPlaying : function (audioSourceIdx) {
        if (!this.audioContext || audioSourceIdx < 0)
            return false;

        if (this.audioSources[audioSourceIdx] == null)
            return false;

        return this.audioSources[audioSourceIdx].isPlaying;
    }
});
