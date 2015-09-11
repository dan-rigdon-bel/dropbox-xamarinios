using System;
using System.Drawing;

using ObjCRuntime;
using Foundation;
using UIKit;

namespace DropboxSDK
{
 
	[BaseType (typeof (NSObject))]
	interface DBAccountInfo {
		[Export ("country")]
		string Country { get;  }

		[Export ("displayName")]
		string DisplayName { get;  }

		[Export ("quota")]
		DBQuota Quota { get;  }

		[Export ("userId")]
		string UserId { get;  }

		[Export ("referralLink")]
		string ReferralLink { get;  }

		[Export ("initWithDictionary:")]
		IntPtr Constructor (NSDictionary dict);

	}

	[BaseType (typeof (UIViewController))]
	interface DBConnectController {
		[Export ("initWithUrl:fromController:session:")]
		IntPtr Constructor (NSUrl connectUrl, UIViewController rootController, DBSession session);

		[Export ("initWithUrl:fromController:")]
		IntPtr Constructor (NSUrl connectUrl, UIViewController rootController);
	}

	[BaseType (typeof (NSObject))]
	interface DBDeltaEntry {
		[Export ("lowercasePath")]
		string LowercasePath { get;  }

		[Export ("metadata")]
		DBMetadata Metadata { get;  }

		[Export ("initWithArray:")]
		IntPtr Constructor (NSArray array);

	}

	[BaseType (typeof (DBJsonBase))]
	interface DBJSON {
		[Export ("fragmentWithString:error:")]
		NSObject FragmentWithString (string jsonrep, out NSError error);

		[Export ("objectWithString:error:")]
		NSObject ObjectWithString (string jsonrep, out NSError error);

		[Export ("objectWithString:allowScalar:error:")]
		NSObject ObjectWithString (NSObject value, bool allowScalar, out NSError error);

		[Export ("stringWithObject:error:")]
		string StringWithObject (NSObject value, out NSError error);

		[Export ("stringWithFragment:error:")]
		string StringWithFragment (NSObject value, out NSError error);

		[Export ("stringWithObject:allowScalar:error:")]
		string StringWithObject (NSObject value, bool allowScalar, out NSError error);

	}

	[BaseType (typeof (NSObject))]
	interface DBJsonBase {
		[Export ("maxDepth")]
		uint maxDepth { get; set;  }

		[Export ("errorTrace")]
		NSArray ErrorTrace { get; }

		[Export ("addErrorWithCode:description:")]
		void AddErrorWithCode (uint code, string str);

		[Export ("clearErrorTrace")]
		void ClearErrorTrace ();
	}

	[BaseType (typeof (DBJsonBase))]
	[Model]
	interface DBJsonParser {
		[Abstract]
		[Export ("objectWithString:")]
		NSObject ObjectWithString (string repr);

	}

	[BaseType (typeof (DBJsonBase))]
	[Model]
	interface DBJsonWriter {
		[Abstract]
		[Export ("humanReadable")]
		bool HumanReadable { get; set;  }

		[Abstract]
		[Export ("sortKeys")]
		bool SortKeys { get; set;  }

		[Abstract]
		[Export ("stringWithObject:")]
		string StringWithObject (NSObject value);

	}

	[BaseType (typeof (NSObject))]
	interface DBKeychain {
		[Static]
		[Export ("setCredentials:")]
		void SetCredentials (NSDictionary credentials);

		[Static]
		[Export ("credentials:")]
		NSDictionary Credentials ();

		[Static]
		[Export ("deleteCredentials")]
		void DeleteCredentials ();

	}

	[BaseType (typeof (NSObject))]
	interface DBMetadata {
		[Export ("thumbnailExists")]
		bool ThumbnailExists { get;  }

		//TODO 
		[Export ("totalBytes")]
		long TotalBytes { get;  }

		[Export ("lastModifiedDate")]
		NSDate LastModifiedDate { get;  }

		[Export ("clientMtime")]
		NSDate ClientMtime { get;  }

		[Export ("path")]
		string Path { get;  }

		[Export ("isDirectory")]
		bool IsDirectory { get;  }

		[Export ("contents")]
		DBMetadata[] Contents { get;  }

		[Export ("hash")]
		string Hash { get;  }

		[Export ("humanReadableSize")]
		string HumanReadableSize { get;  }

		[Export ("root")]
		string Root { get;  }

		[Export ("icon")]
		string Icon { get;  }

		[Export ("long")]
		long Long { get;  }

		[Export ("rev")]
		string Rev { get;  }

		[Export ("isDeleted")]
		bool IsDeleted { get;  }

		[Export ("filename")]
		string Filename { get;  }

		[Export ("initWithDictionary:")]
		IntPtr Constructor (NSDictionary dict);

	}

	[BaseType (typeof (NSObject))]
	interface DBQuota {
		[Export ("normalConsumedBytes")]
		long NormalConsumedBytes { get;  }

		[Export ("sharedConsumedBytes")]
		long SharedConsumedBytes { get;  }

		[Export ("totalConsumedBytes")]
		long TotalConsumedBytes { get;  }

		[Export ("totalBytes")]
		long TotalBytes { get;  }

		[Export ("initWithDictionary:")]
		IntPtr Constructor (NSDictionary dict);

	}

	[BaseType (typeof (NSObject))]
	interface DBRequest {
		[Export ("failureSelector")]
		Selector FailureSelector { get; set;  }

		[Export ("downloadProgressSelector")]
		Selector DownloadProgressSelector { get; set;  }

		[Export ("uploadProgressSelector")]
		Selector UploadProgressSelector { get; set;  }

		[Export ("resultFilename")]
		string ResultFilename { get; set;  }

		[Export ("userInfo")]
		NSDictionary UserInfo { get; set;  }

		[Export ("request")]
		NSUrlRequest Request { get;  }

		[Export ("response")]
		NSHttpUrlResponse Response { get;  }

		[Export ("xDropboxMetadataJSON")]
		NSDictionary XDropboxMetadataJSON { get;  }

		[Export ("statusCode")]
		int StatusCode { get;  }

		[Export ("downloadProgress")]
		float DownloadProgress { get;  }

		[Export ("uploadProgress")]
		float UploadProgress { get;  }

		[Export ("resultData")]
		NSData ResultData { get;  }

		[Export ("resultString")]
		string ResultString { get;  }

		[Export ("resultJSON")]
		NSObject ResultJSON { get;  }

		[Export ("error")]
		NSError Error { get;  }

		[Static]
		[Export ("setNetworkRequestDelegate:")]
		void SetNetworkRequestDelegate (DBNetworkRequestDelegate del);

		[Export ("initWithURLRequest:andInformTarget:selector:")]
		IntPtr Constructor (NSUrlRequest request, NSObject target, Selector selector);

		[Export ("cancel")]
		void Cancel ();

		[Export ("parseResponseAsType:")]
		NSObject ParseResponseAsType (Class cls);

	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface DBNetworkRequestDelegate {
		[Export ("networkRequestStarted")]
		void Started ();

		[Export ("networkRequestStopped")]
		void Stopped ();
	}

	[BaseType (typeof (NSObject),
		Delegates = new string [] {"WeakDelegate"},
		Events = new Type [] { typeof (DBRestClientDelegate) }
	)]
	interface DBRestClient {
		[Wrap ("WeakDelegate")]
		DBRestClientDelegate Delegate { get; set;  }

		[Export ("delegate")]
		NSObject WeakDelegate { get; set; }

		[Export ("initWithSession:")]
		IntPtr Constructor (DBSession session);

		[Export ("initWithSession:userId:")]
		IntPtr Constructor (DBSession session, string userId);

		[Export ("cancelAllRequests")]
		void CancelAllRequests ();

		[Export ("loadMetadata:withParams:")]
		void LoadMetadata (string path, NSDictionary args);

		[Export ("loadMetadata:withHash:")]
		void LoadMetadata (string path, string hash);

		[Export ("loadMetadata:")]
		void LoadMetadata (string path);

		[Export ("loadMetadata:atRev:")]
		void LoadMetadataAtRev (string path, string rev);

		[Export ("loadDelta:")]
		void LoadDelta (string cursor);

		[Export ("loadFile:intoPath:")]
		void LoadFile (string path, string destinationPath);

		[Export ("loadFile:atRev:intoPath:")]
		void LoadFile (string path, string rev, string destPath);

		[Export ("cancelFileLoad:")]
		void CancelFileLoad (string path);

		[Export ("loadThumbnail:ofSize:intoPath:")]
		void LoadThumbnail (string path, string size, string destinationPath);

		[Export ("cancelThumbnailLoad:size:")]
		void CancelThumbnailLoad (string path, string size);

		[Export ("uploadFile:toPath:withParentRev:fromPath:")]
		void UploadFileFromPath (string filename, string path, string parentRev, string sourcePath);

		[Export ("cancelFileUpload:")]
		void CancelFileUpload (string path);

		//TODO
		[Export ("uploadFileChunk:offset:fromPath:")]
		void UploadFileChunk (string uploadId, ulong offset, string localPath);

		[Export ("uploadFile:toPath:withParentRev:fromUploadId:")]
		void UploadFileFromUploadId (string filename, string path, string parentRev, string uploadId);

		[Export ("loadRevisionsForFile:")]
		void LoadRevisionsForFile (string path);

		[Export ("loadRevisionsForFile:limit:")]
		void LoadRevisionsForFilelimit (string path, int limit);

		[Export ("restoreFile:toRev:")]
		void RestoreFile (string path, string rev);

		[Export ("createFolder:")]
		void CreateFolder (string path);

		[Export ("deletePath:")]
		void DeletePath (string path);

		[Export ("copyFrom:toPath:")]
		void CopyFrom (string fromPath, string toPath);

		[Export ("createCopyRef:")]
		void CreateCopyRef (string path);

		[Export ("copyFromRef:toPath:")]
		void CopyFromRef (string copyRef, string toPath);

		[Export ("moveFrom:toPath:")]
		void MoveFrom (string fromPath, string toPath);

		[Export ("loadAccountInfo")]
		void LoadAccountInfo ();

		[Export ("searchPath:forKeyword:")]
		void SearchPath (string path, string keyword);

		[Export ("loadSharableLinkForFile:")]
		void LoadSharableLinkForFile (string path);

		[Export ("loadSharableLinkForFile:shortUrl:")]
		void LoadSharableLinkForFile (string path, bool createShortUrl);

		[Export ("loadStreamableURLForFile:")]
		void LoadStreamableURLForFile (string path);

		[Export ("requestCount")]
		uint RequestCount ();

	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface DBRestClientDelegate {
		[Export ("restClient:loadedMetadata:"), EventArgs ("Metadata")]
		void MetadataLoaded (DBRestClient client, DBMetadata metadata);

		[Export ("restClient:metadataUnchangedAtPath:"), EventArgs ("FilePath")]
		void MetadataUnchangedAtPath (DBRestClient client, string path);

		[Export ("restClient:loadMetadataFailedWithError:"), EventArgs ("NSError")]
		void LoadMetadataFailed (DBRestClient client, NSError error);

		[Export ("restClient:loadedDeltaEntries:reset:cursor:hasMore:"), EventArgs ("Entries")]
		void DeltaEntriesLoaded (DBRestClient client, NSArray entries, bool shouldReset, string cursor, bool hasMore);

		[Export ("restClient:loadDeltaFailedWithError:"), EventArgs ("NSError")]
		void LoadDeltaFailed (DBRestClient client, NSError error);

		[Export ("restClient:loadedAccountInfo:"), EventArgs ("AccountInfo")]
		void AccountInfoLoaded (DBRestClient client, DBAccountInfo info);

		[Export ("restClient:loadAccountInfoFailedWithError:"), EventArgs ("NSError")]
		void LoadAccountInfoFailed (DBRestClient client, NSError error);

		[Export ("restClient:loadedFile:"), EventArgs ("FilePath")]
		void FileLoaded (DBRestClient client, string destPath);

		[Export ("restClient:loadedFile:contentType:metadata:"), EventArgs ("FilePathTypeMetadata")]
		void FileMetadataLoaded (DBRestClient client, string destPath, string contentType, DBMetadata metadata);

		[Export ("restClient:loadProgress:forFile:"), EventArgs ("Progress")]
		void LoadProgress (DBRestClient client, float progress, string destPath);

		[Export ("restClient:loadFileFailedWithError:"), EventArgs ("NSError")]
		void LoadFileFailed (DBRestClient client, NSError error);

		[Export ("restClient:loadedThumbnail:metadata:"), EventArgs ("FilePathMetadata")]
		void ThumbnailMetadataLoaded (DBRestClient client, string destPath, DBMetadata metadata);

		[Export ("restClient:loadThumbnailFailedWithError:"), EventArgs ("NSError")]
		void LoadThumbnailFailed (DBRestClient client, NSError error);

		[Export ("restClient:uploadedFile:from:metadata:"), EventArgs ("FileFromToPathMetadata")]
		void FileMetadataUploaded (DBRestClient client, string destPath, string srcPath, DBMetadata metadata);

		[Export ("restClient:uploadProgress:forFile:from:"), EventArgs ("UploadProgress")]
		void UploadProgress (DBRestClient client, float progress, string destPath, string srcPath);

		[Export ("restClient:uploadFileFailedWithError:"), EventArgs ("NSError")]
		void UploadFileFailed (DBRestClient client, NSError error);

		[Export ("restClient:uploadedFileChunk:newOffset:fromFile:expires:"), EventArgs ("UploadChunk")]
		void FileChunkUploaded (DBRestClient client, string uploadId, ulong offset, string localPath, NSDate expiresDate);

		[Export ("restClient:uploadFileChunkFailedWithError:"), EventArgs ("NSError")]
		void UploadFileChunkFailed (DBRestClient client, NSError error);

		[Export ("restClient:uploadedFile:fromUploadId:metadata:"), EventArgs ("FilePathUploadIdMetadata")]
		void FileUploaded (DBRestClient client, string destPath, string uploadId, DBMetadata metadata);

		[Export ("restClient:uploadFromUploadIdFailedWithError:"), EventArgs ("NSError")]
		void UploadFromUploadIdFailed (DBRestClient client, NSError error);

		[Export ("restClient:loadedRevisions:forFile:"), EventArgs ("Revision")]
		void RevisionsLoaded (DBRestClient client, NSArray revisions, string path);

		[Export ("restClient:loadRevisionsFailedWithError:"), EventArgs ("NSError")]
		void LoadRevisionsFailed (DBRestClient client, NSError error);

		[Export ("restClient:restoredFile:"), EventArgs ("Metadata")]
		void FileRestored (DBRestClient client, DBMetadata fileMetadata);

		[Export ("restClient:restoreFileFailedWithError:"), EventArgs ("NSError")]
		void RestoreFileFailed (DBRestClient client, NSError error);

		[Export ("restClient:createdFolder:"), EventArgs ("Metadata")]
		void FolderCreated (DBRestClient client, DBMetadata folder);

		[Export ("restClient:createFolderFailedWithError:"), EventArgs ("NSError")]
		void CreateFolderFailed (DBRestClient client, NSError error);

		[Export ("restClient:deletedPath:"), EventArgs ("FilePath")]
		void PathDeleted (DBRestClient client, string path);

		[Export ("restClient:deletePathFailedWithError:"), EventArgs ("NSError")]
		void DeletePathFailed (DBRestClient client, NSError error);

		[Export ("restClient:copiedPath:to:"), EventArgs ("FilePathMetadata")]
		void PathCopied (DBRestClient client, string fromPath, DBMetadata to);

		[Export ("restClient:copyPathFailedWithError:"), EventArgs ("NSError")]
		void CopyPathFailed (DBRestClient client, NSError error);

		[Export ("restClient:createdCopyRef:"), EventArgs ("FilePath")]
		void CopyRefCreated (DBRestClient client, string copyRef);

		[Export ("restClient:createCopyRefFailedWithError:"), EventArgs ("NSError")]
		void CreateCopyRefFailed (DBRestClient client, NSError error);

		[Export ("restClient:copiedRef:to:"), EventArgs ("FilePathMetadata")]
		void RefCopied (DBRestClient client, string copyRef, DBMetadata to);

		[Export ("restClient:copyFromRefFailedWithError:"), EventArgs ("NSError")]
		void CopyFromRefFailed (DBRestClient client, NSError error);

		[Export ("restClient:movedPath:pathto:"), EventArgs ("FilePathMetadata")]
		void PathMoved (DBRestClient client, string fromPath, DBMetadata result);

		[Export ("restClient:movePathFailedWithError:"), EventArgs ("NSError")]
		void MovePathFailed (DBRestClient client, NSError error);

		[Export ("restClient:loadedSearchResults:forPath:keyword:"), EventArgs ("SearchResults")]
		void SearchResultsLoaded (DBRestClient restClient, NSArray results, string path, string keyword);

		[Export ("restClient:searchFailedWithError:"), EventArgs ("NSError")]
		void SearchFailed (DBRestClient restClient, NSError error);

		[Export ("restClient:loadedSharableLink:forFile:"), EventArgs ("SharableLink")]
		void SharableLinkLoaded (DBRestClient restClient, string link, string path);

		[Export ("restClient:loadSharableLinkFailedWithError:"), EventArgs ("NSError")]
		void LoadSharableLinkFailed (DBRestClient restClient, NSError error);

		[Export ("restClient:loadedStreamableURL:forFile:"), EventArgs ("StreamableUrl")]
		void StreamableUrlLoaded (DBRestClient restClient, NSUrl url, string path);

		[Export ("restClient:loadStreamableURLFailedWithError:"), EventArgs ("NSError")]
		void LoadStreamableUrlFailed (DBRestClient restClient, NSError error);

	}

	[BaseType (typeof (NSObject), 
		Delegates = new string [] {"WeakDelegate"},
		Events = new Type [] { typeof (DBSessionDelegate) })]
	interface DBSession {
		[Static]
		[Export ("parseURLParams:")]
		NSDictionary ParseUrlParams (string query);

		[Export ("appScheme")]
		string AppScheme ();

		[Export ("linkFromController:")]
		void LinkFromController (UIViewController rootController);

		[Export ("linkUserId:fromController:")]
		void LinkUserIdfromController ([NullAllowed]string userId, UIViewController rootController);

		[Export ("handleOpenURL:")]
		bool HandleOpenUrl (NSUrl url);

		[Export ("root")]
		string Root { get;  }

		[Export ("userIds")]
		string[] UserIds { get;  }

		[Wrap ("WeakDelegate")]
		DBSessionDelegate Delegate { get; set;  }

		[Export ("delegate")]
		NSObject WeakDelegate { get; set; }

		[Export ("initWithAppKey:appSecret:root:")]
		IntPtr Constructor (string key, string secret, string root);

		[Export ("isLinked")]
		bool IsLinked ();

		[Export ("unlinkAll")]
		void UnlinkAll ();

		[Export ("unlinkUserId:")]
		void UnlinkUserId (string userId);

		[Export ("credentialStoreForUserId:")]
		MPOAuthCredentialConcreteStore CredentialStoreForUserId ([NullAllowed] string userId);

		[Export ("updateAccessToken:accessTokenSecret:forUserId:")]
		void UpdateAccessToken (string token, string secret, string userId);

		//Detected properties
		[Static]
		[Export ("sharedSession")]
		DBSession SharedSession { get; set; }
	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface DBSessionDelegate {
		[Export ("sessionDidReceiveAuthorizationFailure:userId:"), EventArgs ("UserId")]
		void AuthorizationFailureReceived (DBSession session, string userId);

	}

	[BaseType (typeof (NSObject))]
	interface MPOAuthCredentialConcreteStore {
		[Export ("baseURL")]
		NSUrl BaseUrl { get;  }

		[Export ("authenticationURL")]
		NSUrl AuthenticationUrl { get;  }

		[Export ("tokenSecret")]
		string TokenSecret { get;  }

		[Export ("signingKey")]
		string SigningKey { get;  }

		[Export ("requestToken")]
		string RequestToken { get; set;  }

		[Export ("requestTokenSecret")]
		string RequestTokenSecret { get; set;  }

		[Export ("accessToken")]
		string AccessToken { get; set;  }

		[Export ("accessTokenSecret")]
		string AccessTokenSecret { get; set;  }

		[Export ("sessionHandle")]
		string SessionHandle { get; set;  }

		[Export ("initWithCredentials:")]
		IntPtr Constructor (NSDictionary inCredential);

		[Export ("initWithCredentials:forBaseURL:")]
		IntPtr Constructor (NSDictionary inCredentials, NSUrl inBaseURL);

		[Export ("initWithCredentials:forBaseURL:withAuthenticationURL:")]
		IntPtr Constructor (NSDictionary inCredentials, NSUrl inBaseURL, NSUrl inAuthenticationURL);

		[Export ("setCredential:withName:")]
		void SetCredentialwithName (NSObject inCredential, string inName);

		[Export ("removeCredentialNamed:")]
		void RemoveCredentialNamed (string inName);

	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface MPOAuthCredentialStore {
		[Abstract]
		[Export ("consumerKey")]
		string ConsumerKey { get;  }

		[Abstract]
		[Export ("consumerSecret")]
		string ConsumerSecret { get;  }

		[Abstract]
		[Export ("username")]
		string Username { get;  }

		[Abstract]
		[Export ("password")]
		string Password { get;  }

		[Abstract]
		[Export ("requestToken")]
		string RequestToken { get;  }

		[Abstract]
		[Export ("requestTokenSecret")]
		string RequestTokenSecret { get;  }

		[Abstract]
		[Export ("accessToken")]
		string AccessToken { get;  }

		[Abstract]
		[Export ("accessTokenSecret")]
		string AccessTokenSecret { get;  }

		[Abstract]
		[Export ("credentialNamed:")]
		string CredentialNamed (string inCredentialName);

		[Abstract]
		[Export ("discardOAuthCredentials")]
		void DiscardOAuthCredentials ();

	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface MPOAuthParameterFactory {
		[Abstract]
		[Export ("signatureMethod")]
		string SignatureMethod { get; set;  }

		[Abstract]
		[Export ("signingKey")]
		string SigningKey { get;  }

		[Abstract]
		[Export ("timestamp")]
		string Timestamp { get;  }

		[Abstract]
		[Export ("oauthParameters")]
		MPURLRequestParameter[] OAuthParameters ();

		[Abstract]
		[Export ("oauthConsumerKeyParameter")]
		MPURLRequestParameter OAuthConsumerKeyParameter ();

		[Abstract]
		[Export ("oauthTokenParameter")]
		MPURLRequestParameter OAuthTokenParameter ();

		[Abstract]
		[Export ("oauthSignatureMethodParameter")]
		MPURLRequestParameter OAuthSignatureMethodParameter ();

		[Abstract]
		[Export ("oauthTimestampParameter")]
		MPURLRequestParameter OAuthTimestampParameter ();

		[Abstract]
		[Export ("oauthNonceParameter")]
		MPURLRequestParameter OAuthNonceParameter ();

		[Abstract]
		[Export ("oauthVersionParameter")]
		MPURLRequestParameter OAuthVersionParameter ();

	}

	[BaseType (typeof (NSObject))]
	interface MPURLRequestParameter {
		[Export ("name")]
		string Name { get; set; }

		[Export ("value")]
		string Value { get; set; }

		[Static]
		[Export ("parametersFromString:")]
		MPURLRequestParameter[] ParametersFromString (string inString);

		[Static]
		[Export ("parametersFromDictionary:")]
		MPURLRequestParameter[] ParametersFromDictionary (NSDictionary inDictionary);

		[Static]
		[Export ("parameterDictionaryFromString:")]
		NSDictionary ParameterDictionaryFromString (string inString);

		[Static]
		[Export ("parameterStringForParameters:")]
		string ParameterStringForParameters (NSArray inParameters);

		[Static]
		[Export ("parameterStringForDictionary:")]
		string ParameterStringForDictionary (NSDictionary inParameterDictionary);

		[Export ("initWithName:andValue:")]
		IntPtr Constuctor (string inName, string inValue);

		[Export ("URLEncodedParameterString")]
		string URLEncodedParameterString ();
	}
}

