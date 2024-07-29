/*
 * PeerTube
 *
 * The PeerTube API is built on HTTP(S) and is RESTful. You can use your favorite HTTP/REST library for your programming language to use PeerTube. The spec API is fully compatible with [openapi-generator](https://github.com/OpenAPITools/openapi-generator/wiki/API-client-generator-HOWTO) which generates a client SDK in the language of your choice - we generate some client SDKs automatically:  - [Python](https://framagit.org/framasoft/peertube/clients/python) - [Go](https://framagit.org/framasoft/peertube/clients/go) - [Kotlin](https://framagit.org/framasoft/peertube/clients/kotlin)  See the [REST API quick start](https://docs.joinpeertube.org/api/rest-getting-started) for a few examples of using the PeerTube API.  # Authentication  When you sign up for an account on a PeerTube instance, you are given the possibility to generate sessions on it, and authenticate there using an access token. Only __one access token can currently be used at a time__.  ## Roles  Accounts are given permissions based on their role. There are three roles on PeerTube: Administrator, Moderator, and User. See the [roles guide](https://docs.joinpeertube.org/admin/managing-users#roles) for a detail of their permissions.  # Errors  The API uses standard HTTP status codes to indicate the success or failure of the API call, completed by a [RFC7807-compliant](https://tools.ietf.org/html/rfc7807) response body.  ``` HTTP 1.1 404 Not Found Content-Type: application/problem+json; charset=utf-8  {   \"detail\": \"Video not found\",   \"docs\": \"https://docs.joinpeertube.org/api-rest-reference.html#operation/getVideo\",   \"status\": 404,   \"title\": \"Not Found\",   \"type\": \"about:blank\" } ```  We provide error `type` (following RFC7807) and `code` (internal PeerTube code) values for [a growing number of cases](https://github.com/Chocobozzz/PeerTube/blob/develop/packages/models/src/server/server-error-code.enum.ts), but it is still optional. Types are used to disambiguate errors that bear the same status code and are non-obvious:  ``` HTTP 1.1 403 Forbidden Content-Type: application/problem+json; charset=utf-8  {   \"detail\": \"Cannot get this video regarding follow constraints\",   \"docs\": \"https://docs.joinpeertube.org/api-rest-reference.html#operation/getVideo\",   \"status\": 403,   \"title\": \"Forbidden\",   \"type\": \"https://docs.joinpeertube.org/api-rest-reference.html#section/Errors/does_not_respect_follow_constraints\" } ```  Here a 403 error could otherwise mean that the video is private or blocklisted.  ### Validation errors  Each parameter is evaluated on its own against a set of rules before the route validator proceeds with potential testing involving parameter combinations. Errors coming from validation errors appear earlier and benefit from a more detailed error description:  ``` HTTP 1.1 400 Bad Request Content-Type: application/problem+json; charset=utf-8  {   \"detail\": \"Incorrect request parameters: id\",   \"docs\": \"https://docs.joinpeertube.org/api-rest-reference.html#operation/getVideo\",   \"instance\": \"/api/v1/videos/9c9de5e8-0a1e-484a-b099-e80766180\",   \"invalid-params\": {     \"id\": {       \"location\": \"params\",       \"msg\": \"Invalid value\",       \"param\": \"id\",       \"value\": \"9c9de5e8-0a1e-484a-b099-e80766180\"     }   },   \"status\": 400,   \"title\": \"Bad Request\",   \"type\": \"about:blank\" } ```  Where `id` is the name of the field concerned by the error, within the route definition. `invalid-params.<field>.location` can be either 'params', 'body', 'header', 'query' or 'cookies', and `invalid-params.<field>.value` reports the value that didn't pass validation whose `invalid-params.<field>.msg` is about.  ### Deprecated error fields  Some fields could be included with previous versions. They are still included but their use is deprecated: - `error`: superseded by `detail`  # Rate limits  We are rate-limiting all endpoints of PeerTube's API. Custom values can be set by administrators:  | Endpoint (prefix: `/api/v1`) | Calls         | Time frame   | |- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -|- -- -- -- -- -- -- --|- -- -- -- -- -- -- -| | `/_*`                         | 50            | 10 seconds   | | `POST /users/token`          | 15            | 5 minutes    | | `POST /users/register`       | 2<sup>*</sup> | 5 minutes    | | `POST /users/ask-send-verify-email` | 3      | 5 minutes    |  Depending on the endpoint, <sup>*</sup>failed requests are not taken into account. A service limit is announced by a `429 Too Many Requests` status code.  You can get details about the current state of your rate limit by reading the following headers:  | Header                  | Description                                                | |- -- -- -- -- -- -- -- -- -- -- -- --|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -| | `X-RateLimit-Limit`     | Number of max requests allowed in the current time period  | | `X-RateLimit-Remaining` | Number of remaining requests in the current time period    | | `X-RateLimit-Reset`     | Timestamp of end of current time period as UNIX timestamp  | | `Retry-After`           | Seconds to delay after the first `429` is received         |  # CORS  This API features [Cross-Origin Resource Sharing (CORS)](https://fetch.spec.whatwg.org/), allowing cross-domain communication from the browser for some routes:  | Endpoint                    | |- -- -- -- -- -- -- -- -- -- -- -- -- - --| | `/api/_*`                    | | `/download/_*`               | | `/lazy-static/_*`            | | `/.well-known/webfinger`    |  In addition, all routes serving ActivityPub are CORS-enabled for all origins. 
 *
 * The version of the OpenAPI document: 6.2.0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using Xunit;

using PeerTubeApiClient.Client;
using PeerTubeApiClient.Api;
// uncomment below to import models
//using PeerTubeApiClient.Model;

namespace PeerTubeApiClient.Test.Api
{
    /// <summary>
    ///  Class for testing VideoPlaylistsApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    public class VideoPlaylistsApiTests : IDisposable
    {
        private VideoPlaylistsApi instance;

        public VideoPlaylistsApiTests()
        {
            instance = new VideoPlaylistsApi();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of VideoPlaylistsApi
        /// </summary>
        [Fact]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsType' VideoPlaylistsApi
            //Assert.IsType<VideoPlaylistsApi>(instance);
        }

        /// <summary>
        /// Test AddPlaylist
        /// </summary>
        [Fact]
        public void AddPlaylistTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string displayName = null;
            //System.IO.Stream? thumbnailfile = null;
            //VideoPlaylistPrivacySet? privacy = null;
            //string? description = null;
            //int? videoChannelId = null;
            //var response = instance.AddPlaylist(displayName, thumbnailfile, privacy, description, videoChannelId);
            //Assert.IsType<AddPlaylist200Response>(response);
        }

        /// <summary>
        /// Test AddVideoPlaylistVideo
        /// </summary>
        [Fact]
        public void AddVideoPlaylistVideoTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int playlistId = null;
            //AddVideoPlaylistVideoRequest? addVideoPlaylistVideoRequest = null;
            //var response = instance.AddVideoPlaylistVideo(playlistId, addVideoPlaylistVideoRequest);
            //Assert.IsType<AddVideoPlaylistVideo200Response>(response);
        }

        /// <summary>
        /// Test ApiV1AccountsNameVideoPlaylistsGet
        /// </summary>
        [Fact]
        public void ApiV1AccountsNameVideoPlaylistsGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string name = null;
            //int? start = null;
            //int? count = null;
            //string? sort = null;
            //string? search = null;
            //VideoPlaylistTypeSet? playlistType = null;
            //var response = instance.ApiV1AccountsNameVideoPlaylistsGet(name, start, count, sort, search, playlistType);
            //Assert.IsType<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response>(response);
        }

        /// <summary>
        /// Test ApiV1UsersMeVideoPlaylistsVideosExistGet
        /// </summary>
        [Fact]
        public void ApiV1UsersMeVideoPlaylistsVideosExistGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //List<int> videoIds = null;
            //var response = instance.ApiV1UsersMeVideoPlaylistsVideosExistGet(videoIds);
            //Assert.IsType<ApiV1UsersMeVideoPlaylistsVideosExistGet200Response>(response);
        }

        /// <summary>
        /// Test ApiV1VideoChannelsChannelHandleVideoPlaylistsGet
        /// </summary>
        [Fact]
        public void ApiV1VideoChannelsChannelHandleVideoPlaylistsGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string channelHandle = null;
            //int? start = null;
            //int? count = null;
            //string? sort = null;
            //VideoPlaylistTypeSet? playlistType = null;
            //var response = instance.ApiV1VideoChannelsChannelHandleVideoPlaylistsGet(channelHandle, start, count, sort, playlistType);
            //Assert.IsType<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response>(response);
        }

        /// <summary>
        /// Test ApiV1VideoPlaylistsPlaylistIdDelete
        /// </summary>
        [Fact]
        public void ApiV1VideoPlaylistsPlaylistIdDeleteTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int playlistId = null;
            //instance.ApiV1VideoPlaylistsPlaylistIdDelete(playlistId);
        }

        /// <summary>
        /// Test ApiV1VideoPlaylistsPlaylistIdGet
        /// </summary>
        [Fact]
        public void ApiV1VideoPlaylistsPlaylistIdGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int playlistId = null;
            //var response = instance.ApiV1VideoPlaylistsPlaylistIdGet(playlistId);
            //Assert.IsType<VideoPlaylist>(response);
        }

        /// <summary>
        /// Test ApiV1VideoPlaylistsPlaylistIdPut
        /// </summary>
        [Fact]
        public void ApiV1VideoPlaylistsPlaylistIdPutTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int playlistId = null;
            //string? displayName = null;
            //System.IO.Stream? thumbnailfile = null;
            //VideoPlaylistPrivacySet? privacy = null;
            //string? description = null;
            //int? videoChannelId = null;
            //instance.ApiV1VideoPlaylistsPlaylistIdPut(playlistId, displayName, thumbnailfile, privacy, description, videoChannelId);
        }

        /// <summary>
        /// Test DelVideoPlaylistVideo
        /// </summary>
        [Fact]
        public void DelVideoPlaylistVideoTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int playlistId = null;
            //int playlistElementId = null;
            //instance.DelVideoPlaylistVideo(playlistId, playlistElementId);
        }

        /// <summary>
        /// Test GetPlaylistPrivacyPolicies
        /// </summary>
        [Fact]
        public void GetPlaylistPrivacyPoliciesTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.GetPlaylistPrivacyPolicies();
            //Assert.IsType<List<string>>(response);
        }

        /// <summary>
        /// Test GetPlaylists
        /// </summary>
        [Fact]
        public void GetPlaylistsTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int? start = null;
            //int? count = null;
            //string? sort = null;
            //VideoPlaylistTypeSet? playlistType = null;
            //var response = instance.GetPlaylists(start, count, sort, playlistType);
            //Assert.IsType<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response>(response);
        }

        /// <summary>
        /// Test GetVideoPlaylistVideos
        /// </summary>
        [Fact]
        public void GetVideoPlaylistVideosTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int playlistId = null;
            //int? start = null;
            //int? count = null;
            //var response = instance.GetVideoPlaylistVideos(playlistId, start, count);
            //Assert.IsType<VideoListResponse>(response);
        }

        /// <summary>
        /// Test PutVideoPlaylistVideo
        /// </summary>
        [Fact]
        public void PutVideoPlaylistVideoTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int playlistId = null;
            //int playlistElementId = null;
            //PutVideoPlaylistVideoRequest? putVideoPlaylistVideoRequest = null;
            //instance.PutVideoPlaylistVideo(playlistId, playlistElementId, putVideoPlaylistVideoRequest);
        }

        /// <summary>
        /// Test ReorderVideoPlaylist
        /// </summary>
        [Fact]
        public void ReorderVideoPlaylistTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int playlistId = null;
            //ReorderVideoPlaylistRequest? reorderVideoPlaylistRequest = null;
            //instance.ReorderVideoPlaylist(playlistId, reorderVideoPlaylistRequest);
        }

        /// <summary>
        /// Test SearchPlaylists
        /// </summary>
        [Fact]
        public void SearchPlaylistsTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string search = null;
            //int? start = null;
            //int? count = null;
            //string? searchTarget = null;
            //string? sort = null;
            //string? host = null;
            //List<string>? uuids = null;
            //var response = instance.SearchPlaylists(search, start, count, searchTarget, sort, host, uuids);
            //Assert.IsType<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response>(response);
        }
    }
}