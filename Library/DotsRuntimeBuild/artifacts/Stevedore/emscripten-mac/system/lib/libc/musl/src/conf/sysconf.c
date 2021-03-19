#include <unistd.h>
#include <limits.h>
#include <errno.h>
#include <sys/resource.h>
#include <signal.h>
#include <sys/sysinfo.h>
#include "syscall.h"
#include "libc.h"

#define JT(x) (-256|(x))
#define VER JT(1)
#define JT_ARG_MAX JT(2)
#define JT_MQ_PRIO_MAX JT(3)
#define JT_PAGE_SIZE JT(4)
#define JT_SEM_VALUE_MAX JT(5)
#define JT_NPROCESSORS_CONF JT(6)
#define JT_NPROCESSORS_ONLN JT(7)
#define JT_PHYS_PAGES JT(8)
#define JT_AVPHYS_PAGES JT(9)
#define JT_ZERO JT(10)

#define RLIM(x) (-32768|(RLIMIT_ ## x))

long sysconf(int name)
{
	static const int values[] = { // XXX EMSCRIPTEN int instead of short
		[_SC_ARG_MAX] = 2097152, // XXX EMSCRIPTEN replace JT_ARG_MAX,
		[_SC_CHILD_MAX] = 47839, // XXX EMSCRIPTEN replace RLIM(NPROC),
		[_SC_CLK_TCK] = 100,
		[_SC_NGROUPS_MAX] = 65536, // XXX EMSCRIPTEN replace 32,
		[_SC_OPEN_MAX] = 1024, // XXX EMSCRIPTEN replace RLIM(NOFILE),
		[_SC_STREAM_MAX] = 16, // XXX EMSCRIPTEN replace -1
		[_SC_TZNAME_MAX] = TZNAME_MAX,
		[_SC_JOB_CONTROL] = 1,
		[_SC_SAVED_IDS] = 1,
		[_SC_REALTIME_SIGNALS] = 200809, // XXX EMSCRIPTEN replace 1,
		[_SC_PRIORITY_SCHEDULING] = 200809, // XXX EMSCRIPTEN replace -1,
		[_SC_TIMERS] = VER,
		[_SC_ASYNCHRONOUS_IO] = VER,
		[_SC_PRIORITIZED_IO] = VER, // XXX EMSCRIPTEN replace -1
		[_SC_SYNCHRONIZED_IO] = 200809, // XXX EMSCRIPTEN replace -1,
		[_SC_FSYNC] = VER,
		[_SC_MAPPED_FILES] = VER,
		[_SC_MEMLOCK] = VER,
		[_SC_MEMLOCK_RANGE] = VER,
		[_SC_MEMORY_PROTECTION] = VER,
		[_SC_MESSAGE_PASSING] = VER,
		[_SC_SEMAPHORES] = VER,
		[_SC_SHARED_MEMORY_OBJECTS] = VER,
		[_SC_AIO_LISTIO_MAX] = -1,
		[_SC_AIO_MAX] = -1,
		[_SC_AIO_PRIO_DELTA_MAX] = 20, // XXX EMSCRIPTEN replace JT_ZERO, /* ?? */
		[_SC_DELAYTIMER_MAX] = 2147483647, // XXX EMSCRIPTEN replace _POSIX_DELAYTIMER_MAX,
		[_SC_MQ_OPEN_MAX] = -1,
		[_SC_MQ_PRIO_MAX] = JT_MQ_PRIO_MAX,
		[_SC_VERSION] = VER,
		[_SC_PAGE_SIZE] = JT_PAGE_SIZE,
		[_SC_RTSIG_MAX] = 32, // XXX EMSCRIPTEN replace _NSIG - 1 - 31 - 3,
		[_SC_SEM_NSEMS_MAX] = -1, // XXX EMSCRIPTEN replace SEM_NSEMS_MAX,
		[_SC_SEM_VALUE_MAX] = JT_SEM_VALUE_MAX,
		[_SC_SIGQUEUE_MAX] = 47839, // XXX EMSCRIPTEN replace -1,
		[_SC_TIMER_MAX] = -1,
		[_SC_BC_BASE_MAX] = _POSIX2_BC_BASE_MAX,
		[_SC_BC_DIM_MAX] = _POSIX2_BC_DIM_MAX,
		[_SC_BC_SCALE_MAX] = _POSIX2_BC_SCALE_MAX,
		[_SC_BC_STRING_MAX] = _POSIX2_BC_STRING_MAX,
		[_SC_COLL_WEIGHTS_MAX] = 255, // XXX EMSCRIPTEN replace COLL_WEIGHTS_MAX,
		[_SC_EXPR_NEST_MAX] = 32, // XXX EMSCRIPTEN replace -1,
		[_SC_LINE_MAX] = 2048, // XXX EMSCRIPTEN replace -1,
		[_SC_RE_DUP_MAX] = 32767, // XXX EMSCRIPTEN replace RE_DUP_MAX,
		[_SC_2_VERSION] = VER,
		[_SC_2_C_BIND] = VER,
		[_SC_2_C_DEV] = 200809, // XXX EMSCRIPTEN replace -1,
		[_SC_2_FORT_DEV] = -1,
		[_SC_2_FORT_RUN] = -1,
		[_SC_2_SW_DEV] = 200809, // XXX EMSCRIPTEN replace -1,
		[_SC_2_LOCALEDEF] = 200809, // XXX EMSCRIPTEN replace -1,
		[_SC_IOV_MAX] = IOV_MAX,
		[_SC_THREADS] = VER,
		[_SC_THREAD_SAFE_FUNCTIONS] = VER,
		[_SC_GETGR_R_SIZE_MAX] = 1024, // XXX EMSCRIPTEN replace -1,
		[_SC_GETPW_R_SIZE_MAX] = 1024, // XXX EMSCRIPTEN replace -1,
		[_SC_LOGIN_NAME_MAX] = 256,
		[_SC_TTY_NAME_MAX] = TTY_NAME_MAX,
		[_SC_THREAD_DESTRUCTOR_ITERATIONS] = PTHREAD_DESTRUCTOR_ITERATIONS,
		[_SC_THREAD_KEYS_MAX] = 1024, // XXX EMSCRIPTEN replace PTHREAD_KEYS_MAX,
		[_SC_THREAD_STACK_MIN] = 16384, // XXX EMSCRIPTEN replace PTHREAD_STACK_MIN,
		[_SC_THREAD_THREADS_MAX] = -1,
		[_SC_THREAD_ATTR_STACKADDR] = VER,
		[_SC_THREAD_ATTR_STACKSIZE] = VER,
		[_SC_THREAD_PRIORITY_SCHEDULING] = VER,
		[_SC_THREAD_PRIO_INHERIT] = 200809, // XXX EMSCRIPTEN replace -1,
		[_SC_THREAD_PRIO_PROTECT] = 200809, // XXX EMSCRIPTEN replace -1,
		[_SC_THREAD_PROCESS_SHARED] = VER,
		[_SC_NPROCESSORS_CONF] = JT_NPROCESSORS_CONF,
		[_SC_NPROCESSORS_ONLN] = JT_NPROCESSORS_ONLN,
		[_SC_PHYS_PAGES] = JT_PHYS_PAGES,
		[_SC_AVPHYS_PAGES] = JT_AVPHYS_PAGES,
		[_SC_ATEXIT_MAX] = 2147483647, // XXX EMSCRIPTEN replace -1,
		[_SC_PASS_MAX] = -1,
		[_SC_XOPEN_VERSION] = _XOPEN_VERSION,
		[_SC_XOPEN_XCU_VERSION] = _XOPEN_VERSION,
		[_SC_XOPEN_UNIX] = 1,
		[_SC_XOPEN_CRYPT] = 1, // XXX EMSCRIPTEN replace -1,
		[_SC_XOPEN_ENH_I18N] = 1,
		[_SC_XOPEN_SHM] = 1,
		[_SC_2_CHAR_TERM] = 200809, // XXX EMSCRIPTEN replace -1,
		[_SC_2_UPE] = -1,
		[_SC_XOPEN_XPG2] = -1,
		[_SC_XOPEN_XPG3] = -1,
		[_SC_XOPEN_XPG4] = -1,
		[_SC_NZERO] = NZERO,
		[_SC_XBS5_ILP32_OFF32] = 1, // XXX EMSCRIPTEN replace -1,
		[_SC_XBS5_ILP32_OFFBIG] = sizeof(long)==4 ? 1 : JT_ZERO,
		[_SC_XBS5_LP64_OFF64] = -1, // XXX EMSCRIPTEN replace sizeof(long)==8 ? 1 : JT_ZERO,
		[_SC_XBS5_LPBIG_OFFBIG] = -1,
		[_SC_XOPEN_LEGACY] = 1, // XXX EMSCRIPTEN replace -1,
		[_SC_XOPEN_REALTIME] = 1, // XXX EMSCRIPTEN replace -1,
		[_SC_XOPEN_REALTIME_THREADS] = 1, // XXX EMSCRIPTEN replace -1,
		[_SC_ADVISORY_INFO] = VER,
		[_SC_BARRIERS] = VER,
		[_SC_CLOCK_SELECTION] = VER,
		[_SC_CPUTIME] = VER,
		[_SC_THREAD_CPUTIME] = VER,
		[_SC_MONOTONIC_CLOCK] = VER,
		[_SC_READER_WRITER_LOCKS] = VER,
		[_SC_SPIN_LOCKS] = VER,
		[_SC_REGEXP] = 1,
		[_SC_SHELL] = 1,
		[_SC_SPAWN] = VER,
		[_SC_SPORADIC_SERVER] = -1,
		[_SC_THREAD_SPORADIC_SERVER] = -1,
		[_SC_TIMEOUTS] = VER,
		[_SC_TYPED_MEMORY_OBJECTS] = -1,
		[_SC_2_PBS] = -1,
		[_SC_2_PBS_ACCOUNTING] = -1,
		[_SC_2_PBS_LOCATE] = -1,
		[_SC_2_PBS_MESSAGE] = -1,
		[_SC_2_PBS_TRACK] = -1,
		[_SC_SYMLOOP_MAX] = -1, // XXX EMSCRIPTEN replace SYMLOOP_MAX,
		[_SC_STREAMS] = JT_ZERO,
		[_SC_2_PBS_CHECKPOINT] = -1,
		[_SC_V6_ILP32_OFF32] = 1, // XXX EMSCRIPTEN replace -1,
		[_SC_V6_ILP32_OFFBIG] = sizeof(long)==4 ? 1 : JT_ZERO,
		[_SC_V6_LP64_OFF64] = -1, // XXX EMSCRIPTEN replace sizeof(long)==8 ? 1 : JT_ZERO,
		[_SC_V6_LPBIG_OFFBIG] = -1,
		[_SC_HOST_NAME_MAX] = 64, // XXX EMSCRIPTEN replace HOST_NAME_MAX,
		[_SC_TRACE] = -1,
		[_SC_TRACE_EVENT_FILTER] = -1,
		[_SC_TRACE_INHERIT] = -1,
		[_SC_TRACE_LOG] = -1,

		[_SC_IPV6] = VER,
		[_SC_RAW_SOCKETS] = VER,
		[_SC_V7_ILP32_OFF32] = -1,
		[_SC_V7_ILP32_OFFBIG] = sizeof(long)==4 ? 1 : JT_ZERO,
		[_SC_V7_LP64_OFF64] = sizeof(long)==8 ? 1 : JT_ZERO,
		[_SC_V7_LPBIG_OFFBIG] = -1,
		[_SC_SS_REPL_MAX] = -1,
		[_SC_TRACE_EVENT_NAME_MAX] = -1,
		[_SC_TRACE_NAME_MAX] = -1,
		[_SC_TRACE_SYS_MAX] = -1,
		[_SC_TRACE_USER_EVENT_MAX] = -1,
		[_SC_XOPEN_STREAMS] = -1, // XXX EMSCRIPTEN replace JT_ZERO,
		[_SC_THREAD_ROBUST_PRIO_INHERIT] = -1,
		[_SC_THREAD_ROBUST_PRIO_PROTECT] = -1,
	};

	if (name >= sizeof(values)/sizeof(values[0]) || !values[name]) {
		errno = EINVAL;
		return -1;
	} else if (values[name] >= -1) {
		return values[name];
	} else if (values[name] < -256) {
		struct rlimit lim;
		getrlimit(values[name]&16383, &lim);
		return lim.rlim_cur > LONG_MAX ? LONG_MAX : lim.rlim_cur;
	}

	switch ((unsigned char)values[name]) {
	case VER & 255:
		return _POSIX_VERSION;
	case JT_ARG_MAX & 255:
		return ARG_MAX;
	case JT_MQ_PRIO_MAX & 255:
		return MQ_PRIO_MAX;
	case JT_PAGE_SIZE & 255:
		return PAGE_SIZE;
	case JT_SEM_VALUE_MAX & 255:
		return SEM_VALUE_MAX;
	case JT_NPROCESSORS_CONF & 255:
	case JT_NPROCESSORS_ONLN & 255: ;
#ifdef __EMSCRIPTEN__
		errno = ENOSYS;
		return -1;
#else
		unsigned char set[128] = {1};
		int i, cnt;
		__syscall(SYS_sched_getaffinity, 0, sizeof set, set);
		for (i=cnt=0; i<sizeof set; i++)
			for (; set[i]; set[i]&=set[i]-1, cnt++);
		return cnt;
#endif
	case JT_PHYS_PAGES & 255:
	case JT_AVPHYS_PAGES & 255: ;
#ifdef __EMSCRIPTEN__
		errno = ENOSYS;
		return -1;
#else
		unsigned long long mem;
		int __lsysinfo(struct sysinfo *);
		struct sysinfo si;
		__lsysinfo(&si);
		if (!si.mem_unit) si.mem_unit = 1;
		if (name==_SC_PHYS_PAGES) mem = si.totalram;
		else mem = si.freeram + si.bufferram;
		mem *= si.mem_unit;
		mem /= PAGE_SIZE;
		return (mem > LONG_MAX) ? LONG_MAX : mem;
#endif
	case JT_ZERO & 255:
		return 0;
	}
	return values[name];
}
