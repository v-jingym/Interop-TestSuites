//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18449
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.Protocols.TestSuites.MS_OXCTABL {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Reflection;
    using Microsoft.SpecExplorer.Runtime.Testing;
    using Microsoft.Protocols.TestTools;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Spec Explorer", "3.5.3130.0")]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class S01_ColumnRops_QueryColumnsAllSuccess_TestSuite : PtfTestClassBase {
        
        public S01_ColumnRops_QueryColumnsAllSuccess_TestSuite() {
            this.SetSwitch("ProceedControlTimeout", "100");
            this.SetSwitch("QuiescenceTimeout", "2000000");
        }
        
        #region Expect Delegates
        public delegate void CheckMAPIHTTPTransportSupportedDelegate1(bool isSupported);
        #endregion
        
        #region Event Metadata
        static System.Reflection.MethodBase CheckMAPIHTTPTransportSupportedInfo = TestManagerHelpers.GetMethodInfo(typeof(Microsoft.Protocols.TestSuites.MS_OXCTABL.IMS_OXCTABLAdapter), "CheckMAPIHTTPTransportSupported", typeof(bool).MakeByRefType());
        #endregion
        
        #region Adapter Instances
        private Microsoft.Protocols.TestSuites.MS_OXCTABL.IMS_OXCTABLAdapter IMS_OXCTABLAdapterInstance;
        #endregion
        
        #region Class Initialization and Cleanup
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void ClassInitialize(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext context) {
            PtfTestClassBase.Initialize(context);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void ClassCleanup() {
            PtfTestClassBase.Cleanup();
        }
        #endregion
        
        #region Test Initialization and Cleanup
        protected override void TestInitialize() {
            this.InitializeTestManager();
            this.IMS_OXCTABLAdapterInstance = ((Microsoft.Protocols.TestSuites.MS_OXCTABL.IMS_OXCTABLAdapter)(this.Manager.GetAdapter(typeof(Microsoft.Protocols.TestSuites.MS_OXCTABL.IMS_OXCTABLAdapter))));
        }
        
        protected override void TestCleanup() {
            base.TestCleanup();
            this.CleanupTestManager();
        }
        #endregion
        
        #region Test Starting in S0
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        public void MSOXCTABL_S01_ColumnRops_QueryColumnsAllSuccess_TestSuite() {
            this.Manager.BeginTest("MSOXCTABL_S01_ColumnRops_QueryColumnsAllSuccess_TestSuite");
            this.Manager.Comment("reaching state \'S0\'");
            bool temp0;
            this.Manager.Comment("executing step \'call CheckMAPIHTTPTransportSupported(out _)\'");
            this.IMS_OXCTABLAdapterInstance.CheckMAPIHTTPTransportSupported(out temp0);
            this.Manager.AddReturn(CheckMAPIHTTPTransportSupportedInfo, null, temp0);
            this.Manager.Comment("reaching state \'S1\'");
            int temp3 = this.Manager.ExpectReturn(this.QuiescenceTimeout, true, new ExpectedReturn(S01_ColumnRops_QueryColumnsAllSuccess_TestSuite.CheckMAPIHTTPTransportSupportedInfo, null, new CheckMAPIHTTPTransportSupportedDelegate1(this.MSOXCTABL_S01_ColumnRops_QueryColumnsAllSuccess_TestSuiteCheckMAPIHTTPTransportSupportedChecker)), new ExpectedReturn(S01_ColumnRops_QueryColumnsAllSuccess_TestSuite.CheckMAPIHTTPTransportSupportedInfo, null, new CheckMAPIHTTPTransportSupportedDelegate1(this.MSOXCTABL_S01_ColumnRops_QueryColumnsAllSuccess_TestSuiteCheckMAPIHTTPTransportSupportedChecker1)));
            if ((temp3 == 0)) {
                this.Manager.Comment("reaching state \'S6\'");
                goto label0;
            }
            if ((temp3 == 1)) {
                this.Manager.Comment("reaching state \'S7\'");
                this.Manager.Comment("executing step \'call InitializeTable(HIERARCHY_TABLE)\'");
                this.IMS_OXCTABLAdapterInstance.InitializeTable(((Microsoft.Protocols.TestSuites.MS_OXCTABL.TableType)(1)));
                this.Manager.Comment("reaching state \'S12\'");
                this.Manager.Comment("checking step \'return InitializeTable\'");
                this.Manager.Comment("reaching state \'S15\'");
                Microsoft.Protocols.TestSuites.MS_OXCTABL.TableRopReturnValues temp1;
                this.Manager.Comment("executing step \'call RopSetColumns(1,False,False,False)\'");
                temp1 = this.IMS_OXCTABLAdapterInstance.RopSetColumns(1u, false, false, false);
                this.Manager.Checkpoint("MS-OXCTABL_R829");
                this.Manager.Checkpoint("MS-OXCTABL_R45");
                this.Manager.Comment("reaching state \'S18\'");
                this.Manager.Comment("checking step \'return RopSetColumns/success\'");
                TestManagerHelpers.AssertAreEqual<Microsoft.Protocols.TestSuites.MS_OXCTABL.TableRopReturnValues>(this.Manager, ((Microsoft.Protocols.TestSuites.MS_OXCTABL.TableRopReturnValues)(0)), temp1, "return of RopSetColumns, state S18");
                this.Manager.Comment("reaching state \'S21\'");
                Microsoft.Protocols.TestSuites.MS_OXCTABL.TableRopReturnValues temp2;
                this.Manager.Comment("executing step \'call RopQueryColumnsAll()\'");
                temp2 = this.IMS_OXCTABLAdapterInstance.RopQueryColumnsAll();
                this.Manager.Checkpoint("MS-OXCTABL_R875");
                this.Manager.Comment("reaching state \'S24\'");
                this.Manager.Comment("checking step \'return RopQueryColumnsAll/success\'");
                TestManagerHelpers.AssertAreEqual<Microsoft.Protocols.TestSuites.MS_OXCTABL.TableRopReturnValues>(this.Manager, ((Microsoft.Protocols.TestSuites.MS_OXCTABL.TableRopReturnValues)(0)), temp2, "return of RopQueryColumnsAll, state S24");
                this.Manager.Comment("reaching state \'S27\'");
                goto label0;
            }
            throw new InvalidOperationException("never reached");
        label0:
;
            this.Manager.EndTest();
        }
        
        private void MSOXCTABL_S01_ColumnRops_QueryColumnsAllSuccess_TestSuiteCheckMAPIHTTPTransportSupportedChecker(bool isSupported) {
            this.Manager.Comment("checking step \'return CheckMAPIHTTPTransportSupported/[out False]\'");
            TestManagerHelpers.AssertAreEqual<bool>(this.Manager, false, isSupported, "isSupported of CheckMAPIHTTPTransportSupported, state S1");
        }
        
        private void MSOXCTABL_S01_ColumnRops_QueryColumnsAllSuccess_TestSuiteCheckMAPIHTTPTransportSupportedChecker1(bool isSupported) {
            this.Manager.Comment("checking step \'return CheckMAPIHTTPTransportSupported/[out True]\'");
            TestManagerHelpers.AssertAreEqual<bool>(this.Manager, true, isSupported, "isSupported of CheckMAPIHTTPTransportSupported, state S1");
        }
        #endregion
        
        #region Test Starting in S2
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        public void MSOXCTABL_S01_ColumnRops_QueryColumnsAllSuccess_TestSuite1() {
            this.Manager.BeginTest("MSOXCTABL_S01_ColumnRops_QueryColumnsAllSuccess_TestSuite1");
            this.Manager.Comment("reaching state \'S2\'");
            bool temp4;
            this.Manager.Comment("executing step \'call CheckMAPIHTTPTransportSupported(out _)\'");
            this.IMS_OXCTABLAdapterInstance.CheckMAPIHTTPTransportSupported(out temp4);
            this.Manager.AddReturn(CheckMAPIHTTPTransportSupportedInfo, null, temp4);
            this.Manager.Comment("reaching state \'S3\'");
            int temp7 = this.Manager.ExpectReturn(this.QuiescenceTimeout, true, new ExpectedReturn(S01_ColumnRops_QueryColumnsAllSuccess_TestSuite.CheckMAPIHTTPTransportSupportedInfo, null, new CheckMAPIHTTPTransportSupportedDelegate1(this.MSOXCTABL_S01_ColumnRops_QueryColumnsAllSuccess_TestSuite1CheckMAPIHTTPTransportSupportedChecker)), new ExpectedReturn(S01_ColumnRops_QueryColumnsAllSuccess_TestSuite.CheckMAPIHTTPTransportSupportedInfo, null, new CheckMAPIHTTPTransportSupportedDelegate1(this.MSOXCTABL_S01_ColumnRops_QueryColumnsAllSuccess_TestSuite1CheckMAPIHTTPTransportSupportedChecker1)));
            if ((temp7 == 0)) {
                this.Manager.Comment("reaching state \'S8\'");
                this.Manager.Comment("executing step \'call InitializeTable(CONTENT_TABLE)\'");
                this.IMS_OXCTABLAdapterInstance.InitializeTable(((Microsoft.Protocols.TestSuites.MS_OXCTABL.TableType)(0)));
                this.Manager.Comment("reaching state \'S13\'");
                this.Manager.Comment("checking step \'return InitializeTable\'");
                this.Manager.Comment("reaching state \'S16\'");
                Microsoft.Protocols.TestSuites.MS_OXCTABL.TableRopReturnValues temp5;
                this.Manager.Comment("executing step \'call RopSetColumns(1,False,False,False)\'");
                temp5 = this.IMS_OXCTABLAdapterInstance.RopSetColumns(1u, false, false, false);
                this.Manager.Checkpoint("MS-OXCTABL_R831");
                this.Manager.Checkpoint("MS-OXCTABL_R45");
                this.Manager.Comment("reaching state \'S19\'");
                this.Manager.Comment("checking step \'return RopSetColumns/success\'");
                TestManagerHelpers.AssertAreEqual<Microsoft.Protocols.TestSuites.MS_OXCTABL.TableRopReturnValues>(this.Manager, ((Microsoft.Protocols.TestSuites.MS_OXCTABL.TableRopReturnValues)(0)), temp5, "return of RopSetColumns, state S19");
                this.Manager.Comment("reaching state \'S22\'");
                Microsoft.Protocols.TestSuites.MS_OXCTABL.TableRopReturnValues temp6;
                this.Manager.Comment("executing step \'call RopQueryColumnsAll()\'");
                temp6 = this.IMS_OXCTABLAdapterInstance.RopQueryColumnsAll();
                this.Manager.Checkpoint("MS-OXCTABL_R876");
                this.Manager.Comment("reaching state \'S25\'");
                this.Manager.Comment("checking step \'return RopQueryColumnsAll/success\'");
                TestManagerHelpers.AssertAreEqual<Microsoft.Protocols.TestSuites.MS_OXCTABL.TableRopReturnValues>(this.Manager, ((Microsoft.Protocols.TestSuites.MS_OXCTABL.TableRopReturnValues)(0)), temp6, "return of RopQueryColumnsAll, state S25");
                this.Manager.Comment("reaching state \'S28\'");
                goto label1;
            }
            if ((temp7 == 1)) {
                this.Manager.Comment("reaching state \'S9\'");
                goto label1;
            }
            throw new InvalidOperationException("never reached");
        label1:
;
            this.Manager.EndTest();
        }
        
        private void MSOXCTABL_S01_ColumnRops_QueryColumnsAllSuccess_TestSuite1CheckMAPIHTTPTransportSupportedChecker(bool isSupported) {
            this.Manager.Comment("checking step \'return CheckMAPIHTTPTransportSupported/[out True]\'");
            TestManagerHelpers.AssertAreEqual<bool>(this.Manager, true, isSupported, "isSupported of CheckMAPIHTTPTransportSupported, state S3");
        }
        
        private void MSOXCTABL_S01_ColumnRops_QueryColumnsAllSuccess_TestSuite1CheckMAPIHTTPTransportSupportedChecker1(bool isSupported) {
            this.Manager.Comment("checking step \'return CheckMAPIHTTPTransportSupported/[out False]\'");
            TestManagerHelpers.AssertAreEqual<bool>(this.Manager, false, isSupported, "isSupported of CheckMAPIHTTPTransportSupported, state S3");
        }
        #endregion
        
        #region Test Starting in S4
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        public void MSOXCTABL_S01_ColumnRops_QueryColumnsAllSuccess_TestSuite2() {
            this.Manager.BeginTest("MSOXCTABL_S01_ColumnRops_QueryColumnsAllSuccess_TestSuite2");
            this.Manager.Comment("reaching state \'S4\'");
            bool temp8;
            this.Manager.Comment("executing step \'call CheckMAPIHTTPTransportSupported(out _)\'");
            this.IMS_OXCTABLAdapterInstance.CheckMAPIHTTPTransportSupported(out temp8);
            this.Manager.AddReturn(CheckMAPIHTTPTransportSupportedInfo, null, temp8);
            this.Manager.Comment("reaching state \'S5\'");
            int temp11 = this.Manager.ExpectReturn(this.QuiescenceTimeout, true, new ExpectedReturn(S01_ColumnRops_QueryColumnsAllSuccess_TestSuite.CheckMAPIHTTPTransportSupportedInfo, null, new CheckMAPIHTTPTransportSupportedDelegate1(this.MSOXCTABL_S01_ColumnRops_QueryColumnsAllSuccess_TestSuite2CheckMAPIHTTPTransportSupportedChecker)), new ExpectedReturn(S01_ColumnRops_QueryColumnsAllSuccess_TestSuite.CheckMAPIHTTPTransportSupportedInfo, null, new CheckMAPIHTTPTransportSupportedDelegate1(this.MSOXCTABL_S01_ColumnRops_QueryColumnsAllSuccess_TestSuite2CheckMAPIHTTPTransportSupportedChecker1)));
            if ((temp11 == 0)) {
                this.Manager.Comment("reaching state \'S10\'");
                this.Manager.Comment("executing step \'call InitializeTable(RULES_TABLE)\'");
                this.IMS_OXCTABLAdapterInstance.InitializeTable(Microsoft.Protocols.TestSuites.MS_OXCTABL.TableType.RULES_TABLE);
                this.Manager.Comment("reaching state \'S14\'");
                this.Manager.Comment("checking step \'return InitializeTable\'");
                this.Manager.Comment("reaching state \'S17\'");
                Microsoft.Protocols.TestSuites.MS_OXCTABL.TableRopReturnValues temp9;
                this.Manager.Comment("executing step \'call RopSetColumns(1,False,False,False)\'");
                temp9 = this.IMS_OXCTABLAdapterInstance.RopSetColumns(1u, false, false, false);
                this.Manager.Checkpoint("MS-OXCTABL_R830");
                this.Manager.Checkpoint("MS-OXCTABL_R45");
                this.Manager.Comment("reaching state \'S20\'");
                this.Manager.Comment("checking step \'return RopSetColumns/success\'");
                TestManagerHelpers.AssertAreEqual<Microsoft.Protocols.TestSuites.MS_OXCTABL.TableRopReturnValues>(this.Manager, ((Microsoft.Protocols.TestSuites.MS_OXCTABL.TableRopReturnValues)(0)), temp9, "return of RopSetColumns, state S20");
                this.Manager.Comment("reaching state \'S23\'");
                Microsoft.Protocols.TestSuites.MS_OXCTABL.TableRopReturnValues temp10;
                this.Manager.Comment("executing step \'call RopQueryColumnsAll()\'");
                temp10 = this.IMS_OXCTABLAdapterInstance.RopQueryColumnsAll();
                this.Manager.Checkpoint("MS-OXCTABL_R877");
                this.Manager.Comment("reaching state \'S26\'");
                this.Manager.Comment("checking step \'return RopQueryColumnsAll/success\'");
                TestManagerHelpers.AssertAreEqual<Microsoft.Protocols.TestSuites.MS_OXCTABL.TableRopReturnValues>(this.Manager, ((Microsoft.Protocols.TestSuites.MS_OXCTABL.TableRopReturnValues)(0)), temp10, "return of RopQueryColumnsAll, state S26");
                this.Manager.Comment("reaching state \'S29\'");
                goto label2;
            }
            if ((temp11 == 1)) {
                this.Manager.Comment("reaching state \'S11\'");
                goto label2;
            }
            throw new InvalidOperationException("never reached");
        label2:
;
            this.Manager.EndTest();
        }
        
        private void MSOXCTABL_S01_ColumnRops_QueryColumnsAllSuccess_TestSuite2CheckMAPIHTTPTransportSupportedChecker(bool isSupported) {
            this.Manager.Comment("checking step \'return CheckMAPIHTTPTransportSupported/[out True]\'");
            TestManagerHelpers.AssertAreEqual<bool>(this.Manager, true, isSupported, "isSupported of CheckMAPIHTTPTransportSupported, state S5");
        }
        
        private void MSOXCTABL_S01_ColumnRops_QueryColumnsAllSuccess_TestSuite2CheckMAPIHTTPTransportSupportedChecker1(bool isSupported) {
            this.Manager.Comment("checking step \'return CheckMAPIHTTPTransportSupported/[out False]\'");
            TestManagerHelpers.AssertAreEqual<bool>(this.Manager, false, isSupported, "isSupported of CheckMAPIHTTPTransportSupported, state S5");
        }
        #endregion
    }
}
