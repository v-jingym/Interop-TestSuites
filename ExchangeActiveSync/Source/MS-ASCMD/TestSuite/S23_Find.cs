﻿namespace Microsoft.Protocols.TestSuites.MS_ASCMD
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Xml;
    using Microsoft.Protocols.TestSuites.Common;
    using Microsoft.Protocols.TestSuites.Common.DataStructures;    
    using Microsoft.Protocols.TestTools;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Request = Microsoft.Protocols.TestSuites.Common.Request;
    using Response = Microsoft.Protocols.TestSuites.Common.Response;

    /// <summary>
    /// This scenario is used to test the Search command.
    /// </summary>
    [TestClass]
    public class S23_Find : TestSuiteBase
    {
        #region Class initialize and clean up
        /// <summary>
        /// Initialize the class.
        /// </summary>
        /// <param name="testContext">VSTS test context.</param>
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            TestClassBase.Initialize(testContext);
        }

        /// <summary>
        /// Clear the class.
        /// </summary>
        [ClassCleanup]
        public static void ClassCleanup()
        {
            TestClassBase.Cleanup();
        }
        #endregion

        #region Test cases
        /// <summary>
        /// This test case is used to verify the success status of Search command.
        /// </summary>
        [TestCategory("MSASCMD"), TestMethod()]
        public void MSASCMD_S23_TC01_Find_Mail_Success()
        {
            Site.Assume.AreEqual<string>("16.1", Common.GetConfigurationPropertyValue("ActiveSyncProtocolVersion", this.Site), "The Find command is only supported when the MS-ASProtocolVersion header is set to 16.1. MS-ASProtocolVersion header value is determined using Common PTFConfig property named ActiveSyncProtocolVersion.");

            #region Create a find request
            FindRequest findRequest = this.CreateMailFindRequest();
            #endregion

            #region Call Find command
            TestSuites.Common.FindResponse findResponse = this.CMDAdapter.Find(findRequest);
            Site.Assert.AreEqual("1", findResponse.ResponseData.Status, "If server successfully completed command, server should return status 1");
            Site.Assert.AreEqual("1", findResponse.ResponseData.Response.Status, "If server successfully completed command, server should return status 1");

            // Add the debug information
            Site.Log.Add(LogEntryKind.Debug, "Verify MS-ASCMD_R72172509");

            // Test Case verify requirement: MS-ASCMD_R72172509
            Site.CaptureRequirementIfAreEqual<string>(
                "1",
                findResponse.ResponseData.Status,
                72172509,
                @"[In Status (Find)] [When the parent is Find element], [the cause of the status value 1 is] Server successfully completed command.");
            
            // Add the debug information
            Site.Log.Add(LogEntryKind.Debug, "Verify MS-ASCMD_R72172520");

            // Test Case verify requirement: MS-ASCMD_R72172520
            Site.CaptureRequirementIfAreEqual<string>(
                "1",
                findResponse.ResponseData.Response.Status,
                72172520,
                @"[In Status (Find)] [When the parent is Find element Response element], [the cause of the status value 1 is] Server successfully completed command.");
            #endregion
        }

        /// <summary>
        /// This test case is used to verify the Find respones status of invalid Find command request.
        /// </summary>
        [TestCategory("MSASCMD"), TestMethod()]
        public void MSASCMD_S23_TC02_Find_Mail_InvalidRequest()
        {
            Site.Assume.AreEqual<string>("16.1", Common.GetConfigurationPropertyValue("ActiveSyncProtocolVersion", this.Site), "The Find command is only supported when the MS-ASProtocolVersion header is set to 16.1. MS-ASProtocolVersion header value is determined using Common PTFConfig property named ActiveSyncProtocolVersion.");
            
            #region Create a find request
            FindRequest findRequest = this.CreateMailFindInvalidRangeRequest();
            #endregion

            #region Call Find command
            TestSuites.Common.FindResponse findResponse = this.CMDAdapter.Find(findRequest);
            Site.Assert.AreEqual("2", findResponse.ResponseData.Status, "If server successfully completed command, server should return status 2");

            // Add the debug information
            Site.Log.Add(LogEntryKind.Debug, "Verify MS-ASCMD_R72172512");

            // Test Case verify requirement: MS-ASCMD_R72172512
            Site.CaptureRequirementIfAreEqual<string>(
                "2",
                findResponse.ResponseData.Status,
                72172512,
                @"[In Status (Find)] [When the parent is Find element], [the cause of the status value 2 is] One or more of the client's search parameters was invalid.");


            if (Common.IsRequirementEnabled(72172521, this.Site))
            {
                // Add the debug information
                Site.Log.Add(LogEntryKind.Debug, "Verify MS-ASCMD_R72172521");

                // Test Case verify requirement: MS-ASCMD_R72172521
                Site.CaptureRequirementIfAreEqual<string>(
                    "2",
                    findResponse.ResponseData.Response.Status,
                    72172521,
                    @"[In Status (Find)] [When the parent is Response element], [the cause of the status value 2 is] One or more of the client's search parameters was invalid.");
            }
            #endregion
        }

        /// <summary>
        /// This test case is used to verify the Find respones status of invalid Range in Find command request.
        /// </summary>
        [TestCategory("MSASCMD"), TestMethod()]
        public void MSASCMD_S23_TC03_Find_Mail_InvalidRange()
        {
            Site.Assume.AreEqual<string>("16.1", Common.GetConfigurationPropertyValue("ActiveSyncProtocolVersion", this.Site), "The Find command is only supported when the MS-ASProtocolVersion header is set to 16.1. MS-ASProtocolVersion header value is determined using Common PTFConfig property named ActiveSyncProtocolVersion.");
            
            #region Create a find request
            FindRequest findRequest = this.CreateMailFindInvalidRangeRequest();
            #endregion

            #region Call Find command
            TestSuites.Common.FindResponse findResponse = this.CMDAdapter.Find(findRequest);
            if (Common.IsRequirementEnabled(72172518, this.Site))
            {                
                Site.Assert.AreEqual("4", findResponse.ResponseData.Response.Status, "If the requested range does not begin with 0, server should return status 4");

                // Add the debug information
                Site.Log.Add(LogEntryKind.Debug, "Verify MS-ASCMD_R72172518");

                // Test Case verify requirement: MS-ASCMD_R72172518
                Site.CaptureRequirementIfAreEqual<string>(
                    "4",
                    findResponse.ResponseData.Response.Status,
                    72172518,
                    @"[In Status (Find)] [When the parent is Response element], [the cause of the status value 4 is] The requested range does not begin with 0.");
            }
            #endregion
        }

        /// <summary>
        /// This test case is used to verify search global address list success
        /// </summary>
        [TestCategory("MSASCMD"), TestMethod()]
        public void MSASCMD_S23_TC04_Find_GAL()
        {
            Site.Assume.AreEqual<string>("16.1", Common.GetConfigurationPropertyValue("ActiveSyncProtocolVersion", this.Site), "The Find command is only supported when the MS-ASProtocolVersion header is set to 16.1. MS-ASProtocolVersion header value is determined using Common PTFConfig property named ActiveSyncProtocolVersion.");
            #region Create Find request with options

            FindRequest findRequest = this.CreateFindGALRequest();
            #endregion

            #region Call find command
            FindResponse findResponse = this.CMDAdapter.Find(findRequest);
            Site.Assert.AreEqual("1", findResponse.ResponseData.Response.Status, "If server successfully completed command, server should return status 1");
            #endregion
        }

        [TestCategory("MSASCMD"), TestMethod()]
        public void MSASCMD_S23_TC05_Find_MatchedItems()
        {
            #region User1 calls SendMail command to send 2 email messages to user2.
            string keyWord = Guid.NewGuid().ToString().Substring(0, 5);
            uint mailIndex = 1;
            string emailSubject = keyWord + Common.GenerateResourceName(Site, "find", mailIndex);
            SendMailResponse responseSendMail = this.SendPlainTextEmail(null, emailSubject, this.User1Information.UserName, this.User2Information.UserName, null);
            Site.Assert.AreEqual(string.Empty, responseSendMail.ResponseDataXML, "If SendMail command executes successfully, server should return empty xml data");
            mailIndex++;
            string emailSubject2 = keyWord + Common.GenerateResourceName(Site, "find", mailIndex);
            SendMailResponse responseSendMail2 = this.SendPlainTextEmail(null, emailSubject2, this.User1Information.UserName, this.User2Information.UserName, null);
            Site.Assert.AreEqual(string.Empty, responseSendMail2.ResponseDataXML, "If SendMail command executes successfully, server should return empty xml data");
            #endregion

            #region Sync user2 mailbox changes
            // Switch to user2 mailbox
            this.SwitchUser(this.User2Information);
            this.GetMailItem(this.User2Information.InboxCollectionId, emailSubject);
            this.GetMailItem(this.User2Information.InboxCollectionId, emailSubject2);
            TestSuiteBase.RecordCaseRelativeItems(this.User2Information, this.User2Information.InboxCollectionId, emailSubject, emailSubject2);
            #endregion

            #region Create a find request for finding mail.
            Request.Find find = new Request.Find
            {
                SearchId = Guid.NewGuid().ToString(),
                ExecuteSearch = new Request.FindExecuteSearch
                {
                    Item = new Request.FindExecuteSearchMailBoxSearchCriterion
                    {
                        Query = new Request.queryType2
                        {
                            ItemsElementName = new Request.ItemsChoiceType11[] { Request.ItemsChoiceType11.FreeText },
                            Items = new string[] { keyWord }
                        },
                        Options = new Request.FindExecuteSearchMailBoxSearchCriterionOptions
                        {
                            Range = "0-5",
                            DeepTraversal = new Request.EmptyTag { }
                            //Picture=new Request.FindExecuteSearchMailBoxSearchCriterionOptionsPicture
                            //{
                            //    MaxSize=2014,
                            //    MaxSizeSpecified=true,
                            //    MaxPictures=5,
                            //    MaxPicturesSpecified=true
                            //}
                        }
                    },

                },
            };

            FindRequest findRequest = this.CreateMailFindRequest();
            ((Request.queryType2)((Request.FindExecuteSearchMailBoxSearchCriterion)find.ExecuteSearch.Item).Query).ItemsElementName = new Request.ItemsChoiceType11[] { Request.ItemsChoiceType11.Class, Request.ItemsChoiceType11.FreeText };
            ((Request.queryType2)((Request.FindExecuteSearchMailBoxSearchCriterion)find.ExecuteSearch.Item).Query).Items = new string[] { "Email", keyWord };

            findRequest.RequestData = find;

            #endregion

            #region Call Find command
            int counter = 0;
            int waitTime = int.Parse(Common.GetConfigurationPropertyValue("WaitTime", this.Site));
            int retryCount = int.Parse(Common.GetConfigurationPropertyValue("RetryCount", this.Site));
            int sendMailCount = 2;
            int resultsCount;
            FindResponse findResponse;

            // Loop search to get correct results.
            do
            {
                Thread.Sleep(waitTime);
                findResponse = this.CMDAdapter.Find(findRequest);
                Site.Assert.AreEqual("1", findResponse.ResponseData.Response.Status, "If server successfully completed command, server should return status 1");
                resultsCount = findResponse.ResponseData.Response.Results.Length;
                counter++;
            }
            while (resultsCount != sendMailCount && counter < retryCount);

            Site.Assert.AreEqual<int>(2, resultsCount, "Find response should contain two search results");
            Site.Log.Add(LogEntryKind.Debug, "Loop {0} times to get the search item", counter);
            #endregion
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Verify if the classElement is supported.
        /// </summary>
        /// <param name="classElement">The class element.</param>
        /// <returns>Return true if class element is supported, return false if class element is not supported.</returns>
        private static bool IsClassSupported(string classElement)
        {
            switch (classElement)
            {
                case "Email":
                    return true;
                case "Tasks":
                    return true;
                case "Calendar":
                    return true;
                case "Contacts":
                    return true;
                case "Notes":
                    return true;
                case "SMS":
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Create search document library request
        /// </summary>
        /// <param name="pointTo">Point to specified folder or item.</param>
        /// <param name="userName">The user name need to access the resource.</param>
        /// <param name="userPassword">The user password.</param>
        /// <returns>The search request.</returns>
        private static SearchRequest CreateSearchDocumentLibraryRequest(string pointTo, string userName, string userPassword)
        {
            Request.SearchStore store = new Request.SearchStore
            {
                Name = SearchName.DocumentLibrary.ToString(),
                Query = new Request.queryType
                {
                    ItemsElementName = new Request.ItemsChoiceType2[] { Request.ItemsChoiceType2.EqualTo },
                    Items = new Request.queryTypeEqualTo[]
                    {
                        new Request.queryTypeEqualTo
                        {
                            LinkId = string.Empty,
                            Value = pointTo
                        }
                    }
                },
                Options = new Request.Options1
                {
                    ItemsElementName =
                        new Request.ItemsChoiceType6[] { Request.ItemsChoiceType6.UserName, Request.ItemsChoiceType6.Password },
                    Items = new object[] { userName, userPassword }
                }
            };

            SearchRequest searchRequest = Common.CreateSearchRequest(new Request.SearchStore[] { store });
            return searchRequest;
        }

        /// <summary>
        /// Get item value from single Result element of Search command.
        /// </summary>
        /// <param name="searchResult">The single Result element of Search command.</param>
        /// <param name="itemType">The item type.</param>
        /// <returns>The item value.</returns>
        private static object GetItemFromSearchResult(Response.SearchResponseStoreResult searchResult, Response.ItemsChoiceType6 itemType)
        {
            for (int index = 0; index < searchResult.Properties.ItemsElementName.Length; index++)
            {
                if (searchResult.Properties.ItemsElementName[index] == itemType)
                {
                    return searchResult.Properties.Items[index];
                }
            }

            return null;
        }

        /// <summary>
        /// Check if all search results contain Body element
        /// </summary>
        /// <param name="searchResponse">The searchResponse</param>
        /// <returns>If all search result contains Body element return true, else return false</returns>
        private static bool FindBodyElementInSearchResponse(SearchResponse searchResponse)
        {
            // Check search result's properties contains Body element
            foreach (Response.SearchResponseStoreResult result in searchResponse.ResponseData.Response.Store.Result)
            {
                bool containBodyElement = false;
                for (int index = 0; index < result.Properties.ItemsElementName.Length; index++)
                {
                    if (result.Properties.ItemsElementName[index] == Response.ItemsChoiceType6.Body && result.Properties.Items[index] != null)
                    {
                        containBodyElement = true;
                        break;
                    }
                }

                if (containBodyElement == false)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Get elements from Search command response.
        /// </summary>
        /// <param name="searchResponse">The Search command response.</param>
        /// <param name="elementType">The element type need to get.</param>
        /// <returns>The element object list.</returns>
        private static List<object> GetElementsFromSearchResponse(SearchResponse searchResponse, Response.ItemsChoiceType6 elementType)
        {
            List<object> element = new List<object>();
            foreach (Response.SearchResponseStoreResult result in searchResponse.ResponseData.Response.Store.Result)
            {
                for (int itemIndex = 0; itemIndex < result.Properties.ItemsElementName.Length; itemIndex++)
                {
                    if (result.Properties.ItemsElementName[itemIndex] == elementType)
                    {
                        element.Add(result.Properties.Items[itemIndex]);
                    }
                }
            }

            return element;
        }

        /// <summary>
        /// Loop calls search command to search special items.
        /// </summary>
        /// <param name="searchRequest">The search request.</param>
        /// <returns>The search response contains results.</returns>
        private SearchResponse LoopSearch(SearchRequest searchRequest)
        {
            int counter = 0;
            int waitTime = int.Parse(Common.GetConfigurationPropertyValue("WaitTime", this.Site));
            int retryCount = int.Parse(Common.GetConfigurationPropertyValue("RetryCount", this.Site));
            int resultsCount;
            SearchResponse searchResponse;

            // Loop search to get correct results.
            do
            {
                Thread.Sleep(waitTime);
                searchResponse = this.CMDAdapter.Search(searchRequest);
                Site.Assert.AreEqual("1", searchResponse.ResponseData.Response.Store.Status, "If server successfully completed command, server should return status 1");
                resultsCount = searchResponse.ResponseData.Response.Store.Result.Length;
                counter++;
            }
            while (resultsCount <= 1 && counter < retryCount && searchResponse.ResponseData.Response.Store.Result[0].Properties == null);
            Site.Assert.IsNotNull(searchResponse.ResponseData.Response.Store.Result[0].Properties, "If search get result, the result should contains properties");
            Site.Log.Add(LogEntryKind.Debug, "Loop {0} times to get the search item", counter);
            return searchResponse;
        }

        /// <summary>
        /// Loop calls search command to get specified results.
        /// </summary>
        /// <param name="searchRequest">The search request.</param>
        /// <param name="totalResult">The result count.</param>
        /// <returns>The search response contains required results.</returns>
        private SearchResponse LoopSearch(SearchRequest searchRequest, int totalResult)
        {
            int counter = 0;
            int waitTime = int.Parse(Common.GetConfigurationPropertyValue("WaitTime", this.Site));
            int retryCount = int.Parse(Common.GetConfigurationPropertyValue("RetryCount", this.Site));
            int resultsCount;
            SearchResponse searchResponse;

            // Loop search to get correct results.
            do
            {
                Thread.Sleep(waitTime);
                searchResponse = this.CMDAdapter.Search(searchRequest);
                Site.Assert.AreEqual("1", searchResponse.ResponseData.Response.Store.Status, "If server successfully completed command, server should return status 1");
                resultsCount = searchResponse.ResponseData.Response.Store.Result.Length;
                counter++;
            }
            while (resultsCount <= 1 && counter < retryCount && (searchResponse.ResponseData.Response.Store.Result[0].Properties == null || Convert.ToInt32(searchResponse.ResponseData.Response.Store.Total) < totalResult));
            Site.Assert.IsNotNull(searchResponse.ResponseData.Response.Store.Result[0].Properties, "If search get result, the result should contains properties");
            Site.Log.Add(LogEntryKind.Debug, "Loop {0} times to get the search item", counter);
            return searchResponse;
        }

        /// <summary>
        /// Respectively create one item in User2 Inbox folder, Calendar folder and Contacts subfolder.
        /// </summary>
        /// <param name="searchPrefix">The prefix in created item.</param>
        private void CreateItemsWithKeyword(string searchPrefix)
        {
            // User1 sends one meeting request mail to use2.
            string meetingRequestSubject = searchPrefix + Common.GenerateResourceName(Site, "subject");
            string attendeeEmailAddress = Common.GetMailAddress(this.User2Information.UserName, this.User2Information.UserDomain);
            Calendar calendar = this.CreateCalendar(meetingRequestSubject, attendeeEmailAddress, null);

            // Send a meeting request email to user2.
            this.SendMeetingRequest(meetingRequestSubject, calendar);

            // Switch to user2 mail box.
            this.SwitchUser(this.User2Information);

            this.GetMailItem(this.User2Information.InboxCollectionId, meetingRequestSubject);
            TestSuiteBase.RecordCaseRelativeItems(this.User2Information, this.User2Information.InboxCollectionId, meetingRequestSubject);
            this.GetMailItem(this.User2Information.CalendarCollectionId, meetingRequestSubject);
            TestSuiteBase.RecordCaseRelativeItems(this.User2Information, this.User2Information.CalendarCollectionId, meetingRequestSubject);

            // Create one contact in Contacts subfolder.
            string contactSubfolderID = this.CreateFolder((byte)FolderType.UserCreatedContacts, Common.GenerateResourceName(Site, "FolderCreate"), this.User2Information.ContactsCollectionId);
            this.FolderSync();
            TestSuiteBase.RecordCaseRelativeFolders(this.User2Information, contactSubfolderID);

            string contactFileAS = searchPrefix + Common.GenerateResourceName(Site, "Contact");
            Request.SyncCollectionAdd addData = this.CreateAddContactCommand("FirstName", "MiddleName", "LastName", contactFileAS, null);

            this.GetInitialSyncResponse(contactSubfolderID);
            SyncRequest syncRequest = TestSuiteBase.CreateSyncAddRequest(this.LastSyncKey, contactSubfolderID, addData);
            this.Sync(syncRequest);
            this.FolderSync();
            this.SyncChanges(contactSubfolderID);
        }

        /// <summary>
        /// Create one search request with MIMESupport and related element
        /// </summary>
        /// <param name="keyWord">Search keyword</param>
        /// <param name="mimeSupportValue">MIMESupport element value</param>
        /// <returns>The search request</returns>
        private SearchRequest CreateSearchRequestWithMimeSupport(string keyWord, byte mimeSupportValue)
        {
            // Create search Option element
            Request.Options1 searchOption = new Request.Options1();
            searchOption.ItemsElementName = new Request.ItemsChoiceType6[] { Request.ItemsChoiceType6.RebuildResults, Request.ItemsChoiceType6.DeepTraversal, Request.ItemsChoiceType6.MIMESupport, Request.ItemsChoiceType6.BodyPreference };

            // Set bodyPrference element value
            Request.BodyPreference bodyPreference = new Request.BodyPreference();
            bodyPreference.Type = 4;
            bodyPreference.TruncationSize = 100;
            bodyPreference.TruncationSizeSpecified = true;

            // Set search Option element value
            searchOption.Items = new object[] { string.Empty, string.Empty, mimeSupportValue, bodyPreference };

            // Create search Query element
            Request.queryType searchQuery = new Request.queryType();
            searchQuery.ItemsElementName = new Request.ItemsChoiceType2[] { Request.ItemsChoiceType2.And };
            searchQuery.Items = new Request.queryType[] { new Request.queryType() };
            ((Request.queryType)searchQuery.Items[0]).ItemsElementName = new Request.ItemsChoiceType2[] { Request.ItemsChoiceType2.Class, Request.ItemsChoiceType2.CollectionId, Request.ItemsChoiceType2.FreeText };
            ((Request.queryType)searchQuery.Items[0]).Items = new object[] { "Email", this.User1Information.InboxCollectionId, keyWord };

            SearchRequest searchRequest = this.CreateDefaultSearchRequest();
            searchRequest.RequestData.Items[0].Options = searchOption;
            searchRequest.RequestData.Items[0].Query = searchQuery;
            return searchRequest;
        }

        /// <summary>
        /// Create invalid Search request.
        /// </summary>
        /// <param name="element">Additional element insert into default search request.</param>
        /// <param name="insertTag">Insert tag shows where the additional element should be inserted.</param>
        /// <returns>String search quest.</returns>
        private string CreateInvalidSearchRequest(string element, string insertTag)
        {
            SearchRequest searchRequest = this.CreateDefaultSearchRequest();
            string originalXmlRequest = searchRequest.GetRequestDataSerializedXML();

            // Remove original element from request.
            if (searchRequest.GetRequestDataSerializedXML().Contains(element))
            {
                originalXmlRequest = searchRequest.GetRequestDataSerializedXML().Replace(element, string.Empty);
            }

            // Insert element before insertTag.
            string invalidSearchRequest = originalXmlRequest.Insert(originalXmlRequest.IndexOf(insertTag, StringComparison.OrdinalIgnoreCase), element);
            return invalidSearchRequest;
        }

        /// <summary>
        /// Create Search GAL request.
        /// </summary>
        /// <param name="maxPictures">The maxPictures value.</param>
        /// <param name="maxSize">The maxSize value.</param>
        /// <param name="requestRange">The range value.</param>
        /// <param name="keyWord">The search key word.</param>
        /// <returns>The GAL search request.</returns>
        private SearchRequest CreateSearchGALRequest(uint maxPictures, uint maxSize, string requestRange, string keyWord)
        {
            // Create search request with range, maxSize, maxPictures options.
            Request.Options1 searchOption = new Request.Options1
            {
                ItemsElementName = new Request.ItemsChoiceType6[] { Request.ItemsChoiceType6.Range, Request.ItemsChoiceType6.Picture }
            };

            if (maxPictures > 0 && maxSize > 0)
            {
                Request.OptionsPicture picture = new Request.OptionsPicture
                {
                    MaxPictures = maxPictures,
                    MaxPicturesSpecified = true,
                    MaxSize = maxSize,
                    MaxSizeSpecified = true
                };
                searchOption.Items = new object[] { requestRange, picture };
            }
            else
            {
                searchOption.Items = new object[] { requestRange };
            }

            Request.queryType searchQuery = new Request.queryType { Text = new string[] { keyWord } };

            // Set Name element, option element, query element in default search request.
            SearchRequest searchRequest = this.CreateDefaultSearchRequest();
            searchRequest.RequestData.Items[0].Name = SearchName.GAL.ToString();
            searchRequest.RequestData.Items[0].Options = searchOption;
            searchRequest.RequestData.Items[0].Query = searchQuery;

            return searchRequest;
        }

        /// <summary>
        /// Create one search request with default value.
        /// </summary>
        /// <returns>Return a SearchRequest instance.</returns>
        private SearchRequest CreateDefaultSearchRequest()
        {
            Request.SearchStore store = new Request.SearchStore
            {
                Name = SearchName.Mailbox.ToString(),
                Options = new Request.Options1
                {
                    Items = new object[] { string.Empty },
                    ItemsElementName = new Request.ItemsChoiceType6[] { Request.ItemsChoiceType6.DeepTraversal }
                },
                Query = new Request.queryType
                {
                    ItemsElementName = new Request.ItemsChoiceType2[] { Request.ItemsChoiceType2.And },
                    Items = new Request.queryType[] { new Request.queryType() }
                }
            };

            ((Request.queryType)store.Query.Items[0]).ItemsElementName = new Request.ItemsChoiceType2[] { Request.ItemsChoiceType2.Class, Request.ItemsChoiceType2.CollectionId, Request.ItemsChoiceType2.FreeText };
            ((Request.queryType)store.Query.Items[0]).Items = new object[] { "Email", this.User1Information.InboxCollectionId, "FreeText" };

            SearchRequest searchRequest = Common.CreateSearchRequest(new Request.SearchStore[] { store });
            return searchRequest;
        }

        /// <summary>
        /// Create one MailBox find request with default value.
        /// </summary>
        /// <returns>Return a MailBox FindRequest instance.</returns>
        private FindRequest CreateMailFindRequest()
        {
            Request.Find find = new Request.Find
            {
                SearchId = Guid.NewGuid().ToString(),
                ExecuteSearch = new Request.FindExecuteSearch
                {
                    Item = new Request.FindExecuteSearchMailBoxSearchCriterion
                    {
                        Query = new Request.queryType2
                        {
                            ItemsElementName = new Request.ItemsChoiceType11[] { Request.ItemsChoiceType11.FreeText},
                            Items = new string[] { "*" }
                        },
                        Options=new Request.FindExecuteSearchMailBoxSearchCriterionOptions
                        {
                            Range = "0-5",
                            DeepTraversal = new Request.EmptyTag { }
                        }
                    },
  
                },
            };

            ((Request.queryType2)((Request.FindExecuteSearchMailBoxSearchCriterion)find.ExecuteSearch.Item).Query).ItemsElementName = new Request.ItemsChoiceType11[] { Request.ItemsChoiceType11.Class, Request.ItemsChoiceType11.FreeText };
            ((Request.queryType2)((Request.FindExecuteSearchMailBoxSearchCriterion)find.ExecuteSearch.Item).Query).Items = new string[] { "Email", "*" };

            FindRequest findRequest = Common.CreateFindRequest(find );
            return findRequest;
        }

        /// <summary>
        /// Create one MailBox find request with invalid value.
        /// </summary>
        /// <returns>Return MailBox FindRequest instance with invalid value.</returns>
        private FindRequest CreateMailFindInvalidRequest()
        {
            Request.Find find = new Request.Find
            {
                SearchId = "",
                ExecuteSearch = new Request.FindExecuteSearch
                {
                    Item = new Request.FindExecuteSearchMailBoxSearchCriterion
                    {
                        Query = new Request.queryType2
                        {
                            ItemsElementName = new Request.ItemsChoiceType11[] { Request.ItemsChoiceType11.FreeText },
                            Items = new string[] { "*" }
                        }
                    },

                },
            };

            ((Request.queryType2)((Request.FindExecuteSearchMailBoxSearchCriterion)find.ExecuteSearch.Item).Query).ItemsElementName = new Request.ItemsChoiceType11[] { Request.ItemsChoiceType11.Class, Request.ItemsChoiceType11.FreeText };
            ((Request.queryType2)((Request.FindExecuteSearchMailBoxSearchCriterion)find.ExecuteSearch.Item).Query).Items = new string[] { "Email", "*" };

            FindRequest findRequest = Common.CreateFindRequest(find);
            return findRequest;
        }

        /// <summary>
        /// Create one MailBox find request with invalid range value.
        /// </summary>
        /// <returns>Return MailBox FindRequest instance with invalid Range value.</returns>
        private FindRequest CreateMailFindInvalidRangeRequest()
        {
            Request.Find find = new Request.Find
            {
                SearchId = Guid.NewGuid().ToString(),
                ExecuteSearch = new Request.FindExecuteSearch
                {
                    Item = new Request.FindExecuteSearchMailBoxSearchCriterion
                    {
                        Query = new Request.queryType2
                        {
                            ItemsElementName = new Request.ItemsChoiceType11[] { Request.ItemsChoiceType11.FreeText },
                            Items = new string[] { "*" }
                        },
                        Options=new Request.FindExecuteSearchMailBoxSearchCriterionOptions
                        {
                            Range="-1-5"
                        }
                    },

                },
            };

            ((Request.queryType2)((Request.FindExecuteSearchMailBoxSearchCriterion)find.ExecuteSearch.Item).Query).ItemsElementName = new Request.ItemsChoiceType11[] { Request.ItemsChoiceType11.Class, Request.ItemsChoiceType11.FreeText };
            ((Request.queryType2)((Request.FindExecuteSearchMailBoxSearchCriterion)find.ExecuteSearch.Item).Query).Items = new string[] { "Email", "*" };
            ((Request.FindExecuteSearchMailBoxSearchCriterion)find.ExecuteSearch.Item).Options.Range = "-1";
            FindRequest findRequest = Common.CreateFindRequest(find); 
            return findRequest;
        }

        /// <summary>
        /// Create Find GAL request.
        /// </summary>
        /// <returns>Return Find GAL request instance.</returns>
        private FindRequest CreateFindGALRequest()
        {
            Request.Find find = new Request.Find
            {
                SearchId = Guid.NewGuid().ToString(),

                ExecuteSearch = new Request.FindExecuteSearch
                {
                    Item = new Request.FindExecuteSearchGALSearchCriterion
                    {
                        Query = Common.GetConfigurationPropertyValue("User1Name", Site),
                        Options = new Request.FindExecuteSearchGALSearchCriterionOptions
                        {
                            Range = "0-5"
                        }
                    },
                },
            };


            //((Request.FindExecuteSearchGALSearchCriterion)find.ExecuteSearch.Item).Query = "*";
            
            //((Request.FindExecuteSearchGALSearchCriterion)find.ExecuteSearch.Item).Options.Range = "0-5";
            //((Request.FindExecuteSearchGALSearchCriterion)find.ExecuteSearch.Item).Query = "*";
            FindRequest findRequest = Common.CreateFindRequest(find);
            return findRequest;
        }
        #endregion
    }
}