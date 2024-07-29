/*
 * PeerTube
 *
 * The PeerTube API is built on HTTP(S) and is RESTful. You can use your favorite HTTP/REST library for your programming language to use PeerTube. The spec API is fully compatible with [openapi-generator](https://github.com/OpenAPITools/openapi-generator/wiki/API-client-generator-HOWTO) which generates a client SDK in the language of your choice - we generate some client SDKs automatically:  - [Python](https://framagit.org/framasoft/peertube/clients/python) - [Go](https://framagit.org/framasoft/peertube/clients/go) - [Kotlin](https://framagit.org/framasoft/peertube/clients/kotlin)  See the [REST API quick start](https://docs.joinpeertube.org/api/rest-getting-started) for a few examples of using the PeerTube API.  # Authentication  When you sign up for an account on a PeerTube instance, you are given the possibility to generate sessions on it, and authenticate there using an access token. Only __one access token can currently be used at a time__.  ## Roles  Accounts are given permissions based on their role. There are three roles on PeerTube: Administrator, Moderator, and User. See the [roles guide](https://docs.joinpeertube.org/admin/managing-users#roles) for a detail of their permissions.  # Errors  The API uses standard HTTP status codes to indicate the success or failure of the API call, completed by a [RFC7807-compliant](https://tools.ietf.org/html/rfc7807) response body.  ``` HTTP 1.1 404 Not Found Content-Type: application/problem+json; charset=utf-8  {   \"detail\": \"Video not found\",   \"docs\": \"https://docs.joinpeertube.org/api-rest-reference.html#operation/getVideo\",   \"status\": 404,   \"title\": \"Not Found\",   \"type\": \"about:blank\" } ```  We provide error `type` (following RFC7807) and `code` (internal PeerTube code) values for [a growing number of cases](https://github.com/Chocobozzz/PeerTube/blob/develop/packages/models/src/server/server-error-code.enum.ts), but it is still optional. Types are used to disambiguate errors that bear the same status code and are non-obvious:  ``` HTTP 1.1 403 Forbidden Content-Type: application/problem+json; charset=utf-8  {   \"detail\": \"Cannot get this video regarding follow constraints\",   \"docs\": \"https://docs.joinpeertube.org/api-rest-reference.html#operation/getVideo\",   \"status\": 403,   \"title\": \"Forbidden\",   \"type\": \"https://docs.joinpeertube.org/api-rest-reference.html#section/Errors/does_not_respect_follow_constraints\" } ```  Here a 403 error could otherwise mean that the video is private or blocklisted.  ### Validation errors  Each parameter is evaluated on its own against a set of rules before the route validator proceeds with potential testing involving parameter combinations. Errors coming from validation errors appear earlier and benefit from a more detailed error description:  ``` HTTP 1.1 400 Bad Request Content-Type: application/problem+json; charset=utf-8  {   \"detail\": \"Incorrect request parameters: id\",   \"docs\": \"https://docs.joinpeertube.org/api-rest-reference.html#operation/getVideo\",   \"instance\": \"/api/v1/videos/9c9de5e8-0a1e-484a-b099-e80766180\",   \"invalid-params\": {     \"id\": {       \"location\": \"params\",       \"msg\": \"Invalid value\",       \"param\": \"id\",       \"value\": \"9c9de5e8-0a1e-484a-b099-e80766180\"     }   },   \"status\": 400,   \"title\": \"Bad Request\",   \"type\": \"about:blank\" } ```  Where `id` is the name of the field concerned by the error, within the route definition. `invalid-params.<field>.location` can be either 'params', 'body', 'header', 'query' or 'cookies', and `invalid-params.<field>.value` reports the value that didn't pass validation whose `invalid-params.<field>.msg` is about.  ### Deprecated error fields  Some fields could be included with previous versions. They are still included but their use is deprecated: - `error`: superseded by `detail`  # Rate limits  We are rate-limiting all endpoints of PeerTube's API. Custom values can be set by administrators:  | Endpoint (prefix: `/api/v1`) | Calls         | Time frame   | |- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -|- -- -- -- -- -- -- --|- -- -- -- -- -- -- -| | `/_*`                         | 50            | 10 seconds   | | `POST /users/token`          | 15            | 5 minutes    | | `POST /users/register`       | 2<sup>*</sup> | 5 minutes    | | `POST /users/ask-send-verify-email` | 3      | 5 minutes    |  Depending on the endpoint, <sup>*</sup>failed requests are not taken into account. A service limit is announced by a `429 Too Many Requests` status code.  You can get details about the current state of your rate limit by reading the following headers:  | Header                  | Description                                                | |- -- -- -- -- -- -- -- -- -- -- -- --|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -| | `X-RateLimit-Limit`     | Number of max requests allowed in the current time period  | | `X-RateLimit-Remaining` | Number of remaining requests in the current time period    | | `X-RateLimit-Reset`     | Timestamp of end of current time period as UNIX timestamp  | | `Retry-After`           | Seconds to delay after the first `429` is received         |  # CORS  This API features [Cross-Origin Resource Sharing (CORS)](https://fetch.spec.whatwg.org/), allowing cross-domain communication from the browser for some routes:  | Endpoint                    | |- -- -- -- -- -- -- -- -- -- -- -- -- - --| | `/api/_*`                    | | `/download/_*`               | | `/lazy-static/_*`            | | `/.well-known/webfinger`    |  In addition, all routes serving ActivityPub are CORS-enabled for all origins. 
 *
 * The version of the OpenAPI document: 6.2.0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mime;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Client.Auth;

namespace PeerTubeApiClient.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IStaticVideoFilesApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Get public HLS video file
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="filename">Filename</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void StaticStreamingPlaylistsHlsFilenameGet(string filename, int operationIndex = 0);

        /// <summary>
        /// Get public HLS video file
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="filename">Filename</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> StaticStreamingPlaylistsHlsFilenameGetWithHttpInfo(string filename, int operationIndex = 0);
        /// <summary>
        /// Get private HLS video file
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="filename">Filename</param>
        /// <param name="videoFileToken">Video file token [generated](#operation/requestVideoToken) by PeerTube so you don&#39;t need to provide an OAuth token in the request header. (optional)</param>
        /// <param name="reinjectVideoFileToken">Ask the server to reinject videoFileToken in URLs in m3u8 playlist (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void StaticStreamingPlaylistsHlsPrivateFilenameGet(string filename, string? videoFileToken = default(string?), bool? reinjectVideoFileToken = default(bool?), int operationIndex = 0);

        /// <summary>
        /// Get private HLS video file
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="filename">Filename</param>
        /// <param name="videoFileToken">Video file token [generated](#operation/requestVideoToken) by PeerTube so you don&#39;t need to provide an OAuth token in the request header. (optional)</param>
        /// <param name="reinjectVideoFileToken">Ask the server to reinject videoFileToken in URLs in m3u8 playlist (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> StaticStreamingPlaylistsHlsPrivateFilenameGetWithHttpInfo(string filename, string? videoFileToken = default(string?), bool? reinjectVideoFileToken = default(bool?), int operationIndex = 0);
        /// <summary>
        /// Get public Web Video file
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.0**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="filename">Filename</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void StaticWebVideosFilenameGet(string filename, int operationIndex = 0);

        /// <summary>
        /// Get public Web Video file
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.0**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="filename">Filename</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> StaticWebVideosFilenameGetWithHttpInfo(string filename, int operationIndex = 0);
        /// <summary>
        /// Get private Web Video file
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.0**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="filename">Filename</param>
        /// <param name="videoFileToken">Video file token [generated](#operation/requestVideoToken) by PeerTube so you don&#39;t need to provide an OAuth token in the request header. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void StaticWebVideosPrivateFilenameGet(string filename, string? videoFileToken = default(string?), int operationIndex = 0);

        /// <summary>
        /// Get private Web Video file
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.0**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="filename">Filename</param>
        /// <param name="videoFileToken">Video file token [generated](#operation/requestVideoToken) by PeerTube so you don&#39;t need to provide an OAuth token in the request header. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> StaticWebVideosPrivateFilenameGetWithHttpInfo(string filename, string? videoFileToken = default(string?), int operationIndex = 0);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IStaticVideoFilesApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Get public HLS video file
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="filename">Filename</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task StaticStreamingPlaylistsHlsFilenameGetAsync(string filename, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get public HLS video file
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="filename">Filename</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> StaticStreamingPlaylistsHlsFilenameGetWithHttpInfoAsync(string filename, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get private HLS video file
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="filename">Filename</param>
        /// <param name="videoFileToken">Video file token [generated](#operation/requestVideoToken) by PeerTube so you don&#39;t need to provide an OAuth token in the request header. (optional)</param>
        /// <param name="reinjectVideoFileToken">Ask the server to reinject videoFileToken in URLs in m3u8 playlist (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task StaticStreamingPlaylistsHlsPrivateFilenameGetAsync(string filename, string? videoFileToken = default(string?), bool? reinjectVideoFileToken = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get private HLS video file
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="filename">Filename</param>
        /// <param name="videoFileToken">Video file token [generated](#operation/requestVideoToken) by PeerTube so you don&#39;t need to provide an OAuth token in the request header. (optional)</param>
        /// <param name="reinjectVideoFileToken">Ask the server to reinject videoFileToken in URLs in m3u8 playlist (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> StaticStreamingPlaylistsHlsPrivateFilenameGetWithHttpInfoAsync(string filename, string? videoFileToken = default(string?), bool? reinjectVideoFileToken = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get public Web Video file
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.0**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="filename">Filename</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task StaticWebVideosFilenameGetAsync(string filename, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get public Web Video file
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.0**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="filename">Filename</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> StaticWebVideosFilenameGetWithHttpInfoAsync(string filename, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get private Web Video file
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.0**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="filename">Filename</param>
        /// <param name="videoFileToken">Video file token [generated](#operation/requestVideoToken) by PeerTube so you don&#39;t need to provide an OAuth token in the request header. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task StaticWebVideosPrivateFilenameGetAsync(string filename, string? videoFileToken = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get private Web Video file
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.0**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="filename">Filename</param>
        /// <param name="videoFileToken">Video file token [generated](#operation/requestVideoToken) by PeerTube so you don&#39;t need to provide an OAuth token in the request header. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> StaticWebVideosPrivateFilenameGetWithHttpInfoAsync(string filename, string? videoFileToken = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IStaticVideoFilesApi : IStaticVideoFilesApiSync, IStaticVideoFilesApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class StaticVideoFilesApi : IStaticVideoFilesApi
    {
        private PeerTubeApiClient.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="StaticVideoFilesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public StaticVideoFilesApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StaticVideoFilesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public StaticVideoFilesApi(string basePath)
        {
            this.Configuration = PeerTubeApiClient.Client.Configuration.MergeConfigurations(
                PeerTubeApiClient.Client.GlobalConfiguration.Instance,
                new PeerTubeApiClient.Client.Configuration { BasePath = basePath }
            );
            this.Client = new PeerTubeApiClient.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new PeerTubeApiClient.Client.ApiClient(this.Configuration.BasePath);
            this.ExceptionFactory = PeerTubeApiClient.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StaticVideoFilesApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public StaticVideoFilesApi(PeerTubeApiClient.Client.Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Configuration = PeerTubeApiClient.Client.Configuration.MergeConfigurations(
                PeerTubeApiClient.Client.GlobalConfiguration.Instance,
                configuration
            );
            this.Client = new PeerTubeApiClient.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new PeerTubeApiClient.Client.ApiClient(this.Configuration.BasePath);
            ExceptionFactory = PeerTubeApiClient.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StaticVideoFilesApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public StaticVideoFilesApi(PeerTubeApiClient.Client.ISynchronousClient client, PeerTubeApiClient.Client.IAsynchronousClient asyncClient, PeerTubeApiClient.Client.IReadableConfiguration configuration)
        {
            if (client == null) throw new ArgumentNullException("client");
            if (asyncClient == null) throw new ArgumentNullException("asyncClient");
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Client = client;
            this.AsynchronousClient = asyncClient;
            this.Configuration = configuration;
            this.ExceptionFactory = PeerTubeApiClient.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// The client for accessing this underlying API asynchronously.
        /// </summary>
        public PeerTubeApiClient.Client.IAsynchronousClient AsynchronousClient { get; set; }

        /// <summary>
        /// The client for accessing this underlying API synchronously.
        /// </summary>
        public PeerTubeApiClient.Client.ISynchronousClient Client { get; set; }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public string GetBasePath()
        {
            return this.Configuration.BasePath;
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public PeerTubeApiClient.Client.IReadableConfiguration Configuration { get; set; }

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public PeerTubeApiClient.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Get public HLS video file 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="filename">Filename</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void StaticStreamingPlaylistsHlsFilenameGet(string filename, int operationIndex = 0)
        {
            StaticStreamingPlaylistsHlsFilenameGetWithHttpInfo(filename);
        }

        /// <summary>
        /// Get public HLS video file 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="filename">Filename</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> StaticStreamingPlaylistsHlsFilenameGetWithHttpInfo(string filename, int operationIndex = 0)
        {
            // verify the required parameter 'filename' is set
            if (filename == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'filename' when calling StaticVideoFilesApi->StaticStreamingPlaylistsHlsFilenameGet");
            }

            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
            };

            var localVarContentType = PeerTubeApiClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = PeerTubeApiClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("filename", PeerTubeApiClient.Client.ClientUtils.ParameterToString(filename)); // path parameter

            localVarRequestOptions.Operation = "StaticVideoFilesApi.StaticStreamingPlaylistsHlsFilenameGet";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (OAuth2) required
            // oauth required
            if (!localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
                {
                    localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
                }
                else if (!string.IsNullOrEmpty(this.Configuration.OAuthTokenUrl) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientId) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientSecret) &&
                         this.Configuration.OAuthFlow != null)
                {
                    localVarRequestOptions.OAuth = true;
                }
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<Object>("/static/streaming-playlists/hls/{filename}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("StaticStreamingPlaylistsHlsFilenameGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get public HLS video file 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="filename">Filename</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task StaticStreamingPlaylistsHlsFilenameGetAsync(string filename, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await StaticStreamingPlaylistsHlsFilenameGetWithHttpInfoAsync(filename, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get public HLS video file 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="filename">Filename</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> StaticStreamingPlaylistsHlsFilenameGetWithHttpInfoAsync(string filename, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'filename' is set
            if (filename == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'filename' when calling StaticVideoFilesApi->StaticStreamingPlaylistsHlsFilenameGet");
            }


            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
            };

            var localVarContentType = PeerTubeApiClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = PeerTubeApiClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("filename", PeerTubeApiClient.Client.ClientUtils.ParameterToString(filename)); // path parameter

            localVarRequestOptions.Operation = "StaticVideoFilesApi.StaticStreamingPlaylistsHlsFilenameGet";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (OAuth2) required
            // oauth required
            if (!localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
                {
                    localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
                }
                else if (!string.IsNullOrEmpty(this.Configuration.OAuthTokenUrl) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientId) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientSecret) &&
                         this.Configuration.OAuthFlow != null)
                {
                    localVarRequestOptions.OAuth = true;
                }
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<Object>("/static/streaming-playlists/hls/{filename}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("StaticStreamingPlaylistsHlsFilenameGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get private HLS video file 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="filename">Filename</param>
        /// <param name="videoFileToken">Video file token [generated](#operation/requestVideoToken) by PeerTube so you don&#39;t need to provide an OAuth token in the request header. (optional)</param>
        /// <param name="reinjectVideoFileToken">Ask the server to reinject videoFileToken in URLs in m3u8 playlist (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void StaticStreamingPlaylistsHlsPrivateFilenameGet(string filename, string? videoFileToken = default(string?), bool? reinjectVideoFileToken = default(bool?), int operationIndex = 0)
        {
            StaticStreamingPlaylistsHlsPrivateFilenameGetWithHttpInfo(filename, videoFileToken, reinjectVideoFileToken);
        }

        /// <summary>
        /// Get private HLS video file 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="filename">Filename</param>
        /// <param name="videoFileToken">Video file token [generated](#operation/requestVideoToken) by PeerTube so you don&#39;t need to provide an OAuth token in the request header. (optional)</param>
        /// <param name="reinjectVideoFileToken">Ask the server to reinject videoFileToken in URLs in m3u8 playlist (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> StaticStreamingPlaylistsHlsPrivateFilenameGetWithHttpInfo(string filename, string? videoFileToken = default(string?), bool? reinjectVideoFileToken = default(bool?), int operationIndex = 0)
        {
            // verify the required parameter 'filename' is set
            if (filename == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'filename' when calling StaticVideoFilesApi->StaticStreamingPlaylistsHlsPrivateFilenameGet");
            }

            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
            };

            var localVarContentType = PeerTubeApiClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = PeerTubeApiClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("filename", PeerTubeApiClient.Client.ClientUtils.ParameterToString(filename)); // path parameter
            if (videoFileToken != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "videoFileToken", videoFileToken));
            }
            if (reinjectVideoFileToken != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "reinjectVideoFileToken", reinjectVideoFileToken));
            }

            localVarRequestOptions.Operation = "StaticVideoFilesApi.StaticStreamingPlaylistsHlsPrivateFilenameGet";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (OAuth2) required
            // oauth required
            if (!localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
                {
                    localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
                }
                else if (!string.IsNullOrEmpty(this.Configuration.OAuthTokenUrl) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientId) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientSecret) &&
                         this.Configuration.OAuthFlow != null)
                {
                    localVarRequestOptions.OAuth = true;
                }
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<Object>("/static/streaming-playlists/hls/private/{filename}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("StaticStreamingPlaylistsHlsPrivateFilenameGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get private HLS video file 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="filename">Filename</param>
        /// <param name="videoFileToken">Video file token [generated](#operation/requestVideoToken) by PeerTube so you don&#39;t need to provide an OAuth token in the request header. (optional)</param>
        /// <param name="reinjectVideoFileToken">Ask the server to reinject videoFileToken in URLs in m3u8 playlist (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task StaticStreamingPlaylistsHlsPrivateFilenameGetAsync(string filename, string? videoFileToken = default(string?), bool? reinjectVideoFileToken = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await StaticStreamingPlaylistsHlsPrivateFilenameGetWithHttpInfoAsync(filename, videoFileToken, reinjectVideoFileToken, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get private HLS video file 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="filename">Filename</param>
        /// <param name="videoFileToken">Video file token [generated](#operation/requestVideoToken) by PeerTube so you don&#39;t need to provide an OAuth token in the request header. (optional)</param>
        /// <param name="reinjectVideoFileToken">Ask the server to reinject videoFileToken in URLs in m3u8 playlist (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> StaticStreamingPlaylistsHlsPrivateFilenameGetWithHttpInfoAsync(string filename, string? videoFileToken = default(string?), bool? reinjectVideoFileToken = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'filename' is set
            if (filename == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'filename' when calling StaticVideoFilesApi->StaticStreamingPlaylistsHlsPrivateFilenameGet");
            }


            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
            };

            var localVarContentType = PeerTubeApiClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = PeerTubeApiClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("filename", PeerTubeApiClient.Client.ClientUtils.ParameterToString(filename)); // path parameter
            if (videoFileToken != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "videoFileToken", videoFileToken));
            }
            if (reinjectVideoFileToken != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "reinjectVideoFileToken", reinjectVideoFileToken));
            }

            localVarRequestOptions.Operation = "StaticVideoFilesApi.StaticStreamingPlaylistsHlsPrivateFilenameGet";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (OAuth2) required
            // oauth required
            if (!localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
                {
                    localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
                }
                else if (!string.IsNullOrEmpty(this.Configuration.OAuthTokenUrl) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientId) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientSecret) &&
                         this.Configuration.OAuthFlow != null)
                {
                    localVarRequestOptions.OAuth = true;
                }
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<Object>("/static/streaming-playlists/hls/private/{filename}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("StaticStreamingPlaylistsHlsPrivateFilenameGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get public Web Video file **PeerTube &gt;&#x3D; 6.0**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="filename">Filename</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void StaticWebVideosFilenameGet(string filename, int operationIndex = 0)
        {
            StaticWebVideosFilenameGetWithHttpInfo(filename);
        }

        /// <summary>
        /// Get public Web Video file **PeerTube &gt;&#x3D; 6.0**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="filename">Filename</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> StaticWebVideosFilenameGetWithHttpInfo(string filename, int operationIndex = 0)
        {
            // verify the required parameter 'filename' is set
            if (filename == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'filename' when calling StaticVideoFilesApi->StaticWebVideosFilenameGet");
            }

            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
            };

            var localVarContentType = PeerTubeApiClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = PeerTubeApiClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("filename", PeerTubeApiClient.Client.ClientUtils.ParameterToString(filename)); // path parameter

            localVarRequestOptions.Operation = "StaticVideoFilesApi.StaticWebVideosFilenameGet";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<Object>("/static/web-videos/{filename}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("StaticWebVideosFilenameGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get public Web Video file **PeerTube &gt;&#x3D; 6.0**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="filename">Filename</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task StaticWebVideosFilenameGetAsync(string filename, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await StaticWebVideosFilenameGetWithHttpInfoAsync(filename, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get public Web Video file **PeerTube &gt;&#x3D; 6.0**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="filename">Filename</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> StaticWebVideosFilenameGetWithHttpInfoAsync(string filename, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'filename' is set
            if (filename == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'filename' when calling StaticVideoFilesApi->StaticWebVideosFilenameGet");
            }


            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
            };

            var localVarContentType = PeerTubeApiClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = PeerTubeApiClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("filename", PeerTubeApiClient.Client.ClientUtils.ParameterToString(filename)); // path parameter

            localVarRequestOptions.Operation = "StaticVideoFilesApi.StaticWebVideosFilenameGet";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<Object>("/static/web-videos/{filename}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("StaticWebVideosFilenameGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get private Web Video file **PeerTube &gt;&#x3D; 6.0**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="filename">Filename</param>
        /// <param name="videoFileToken">Video file token [generated](#operation/requestVideoToken) by PeerTube so you don&#39;t need to provide an OAuth token in the request header. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void StaticWebVideosPrivateFilenameGet(string filename, string? videoFileToken = default(string?), int operationIndex = 0)
        {
            StaticWebVideosPrivateFilenameGetWithHttpInfo(filename, videoFileToken);
        }

        /// <summary>
        /// Get private Web Video file **PeerTube &gt;&#x3D; 6.0**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="filename">Filename</param>
        /// <param name="videoFileToken">Video file token [generated](#operation/requestVideoToken) by PeerTube so you don&#39;t need to provide an OAuth token in the request header. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> StaticWebVideosPrivateFilenameGetWithHttpInfo(string filename, string? videoFileToken = default(string?), int operationIndex = 0)
        {
            // verify the required parameter 'filename' is set
            if (filename == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'filename' when calling StaticVideoFilesApi->StaticWebVideosPrivateFilenameGet");
            }

            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
            };

            var localVarContentType = PeerTubeApiClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = PeerTubeApiClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("filename", PeerTubeApiClient.Client.ClientUtils.ParameterToString(filename)); // path parameter
            if (videoFileToken != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "videoFileToken", videoFileToken));
            }

            localVarRequestOptions.Operation = "StaticVideoFilesApi.StaticWebVideosPrivateFilenameGet";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (OAuth2) required
            // oauth required
            if (!localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
                {
                    localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
                }
                else if (!string.IsNullOrEmpty(this.Configuration.OAuthTokenUrl) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientId) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientSecret) &&
                         this.Configuration.OAuthFlow != null)
                {
                    localVarRequestOptions.OAuth = true;
                }
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<Object>("/static/web-videos/private/{filename}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("StaticWebVideosPrivateFilenameGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get private Web Video file **PeerTube &gt;&#x3D; 6.0**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="filename">Filename</param>
        /// <param name="videoFileToken">Video file token [generated](#operation/requestVideoToken) by PeerTube so you don&#39;t need to provide an OAuth token in the request header. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task StaticWebVideosPrivateFilenameGetAsync(string filename, string? videoFileToken = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await StaticWebVideosPrivateFilenameGetWithHttpInfoAsync(filename, videoFileToken, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get private Web Video file **PeerTube &gt;&#x3D; 6.0**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="filename">Filename</param>
        /// <param name="videoFileToken">Video file token [generated](#operation/requestVideoToken) by PeerTube so you don&#39;t need to provide an OAuth token in the request header. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> StaticWebVideosPrivateFilenameGetWithHttpInfoAsync(string filename, string? videoFileToken = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'filename' is set
            if (filename == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'filename' when calling StaticVideoFilesApi->StaticWebVideosPrivateFilenameGet");
            }


            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
            };

            var localVarContentType = PeerTubeApiClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = PeerTubeApiClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("filename", PeerTubeApiClient.Client.ClientUtils.ParameterToString(filename)); // path parameter
            if (videoFileToken != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "videoFileToken", videoFileToken));
            }

            localVarRequestOptions.Operation = "StaticVideoFilesApi.StaticWebVideosPrivateFilenameGet";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (OAuth2) required
            // oauth required
            if (!localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
                {
                    localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
                }
                else if (!string.IsNullOrEmpty(this.Configuration.OAuthTokenUrl) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientId) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientSecret) &&
                         this.Configuration.OAuthFlow != null)
                {
                    localVarRequestOptions.OAuth = true;
                }
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<Object>("/static/web-videos/private/{filename}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("StaticWebVideosPrivateFilenameGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

    }
}