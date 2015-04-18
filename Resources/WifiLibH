#ifndef KY_GETURL_HDR
#define KY_GETURL_HDR

#ifdef __cplusplus
extern "C" {
#endif

extern int ky_errno;
extern int ky_h_errno;



#ifdef ARM9
	#include <nds.h>
	#include <dswifi9.h>
#else
	#ifndef __USE_MISC
		#define __USE_MISC
	#endif
	
	#include <arpa/inet.h>
	#include <sys/ioctl.h>
#endif

#include <stddef.h>
#include <stdlib.h>
#include <string.h>
#include <stdio.h>
#include <errno.h>
#include <sys/time.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <netdb.h>

#if !defined(ARM9) && !defined(WIN32)
	#include <unistd.h>
	#define closesocket close /* no closesocket in linux .. */
#endif

#ifndef h_errno
	#define h_errno ky_h_errno
#endif

typedef unsigned char bchar;

/* you prolly don't wanna use SOCK_NON_BLOCKING mode,
 * it's unreliable, and ky_GetUrl/Ex doesn't support it
 * so if you use it, you must check for the error and try again
 */
typedef enum SocketMode {
	SOCK_BLOCKING,
	SOCK_NON_BLOCKING
} eSocketMode;

typedef struct Buffer {
	bchar *buf; /* the real start of the buffer .. use ky_FreeBuffer */
	const bchar *buffer; /* the start of the actual content (after \r\n\r\n) */
	ssize_t length;
} sBuffer;

typedef struct Link {
	int socket;
	uint16_t port;
	char *host;
	const char *query;
} sLink;

/* ky defines */

#define ky_VERSION "2.2.1"

#define ky_Free(m_ptr) if (m_ptr) {free(m_ptr); (m_ptr) = NULL;}

#define ky_SUCCESS 0 /* a common interface to all error statuses */

#ifndef ky_CHUNK_SIZE
	#define ky_CHUNK_SIZE 512
#endif

#ifndef ky_PORT
	#define ky_PORT 80
#endif

#ifndef ky_TIMEOUT
	#define ky_TIMEOUT 1 /* seconds */
#endif

#ifndef ky_RETRY
	#define ky_RETRY 2
#endif

#ifndef ky_USERAGENT
	#define ky_USERAGENT "User-Agent: Mozilla/4.0 (compatible; "       \
	                     "ky.GetUrl/"ky_VERSION"; Nintendo DS)\r\n"
#endif




/*(proto*/
int ky_AutoConnectWifi (void);
int ky_ConnectEx (sLink *lnk, eSocketMode mode, unsigned int timeout);
int ky_Connect (sLink *lnk);
void ky_Disconnect (sLink *lnk);
char* ky_Strndup (const char *buf, size_t n);
int ky_InitLink (sLink *lnk, const char *url);
void ky_FreeLink (sLink *lnk);
void ky_FreeBuffer (sBuffer *bfr);
void ky_InitBuffer (sBuffer *bfr);
int ky_SaneLink (const sLink *lnk);
int ky_Get (int socket, bchar *buf, size_t len, ssize_t *recvd);
int ky_Query (sLink *lnk, const char *query);
int ky_QueryLink (sLink *lnk);
size_t ky_PredictBufferLength (char *buf);
int ky_GetUrlEx (sLink *lnk, sBuffer *bfr);
int ky_GetUrl (const char *url, sBuffer *bfr);
/*proto)*/

#ifdef __cplusplus
}
#endif

#endif
