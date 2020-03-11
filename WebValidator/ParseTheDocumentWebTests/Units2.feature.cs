// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:3.1.0.0
//      SpecFlow Generator Version:3.1.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace ParseTheDocumentWebTests
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Units2")]
    public partial class Units2Feature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "Units2.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Units2", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Unit 1")]
        [NUnit.Framework.CategoryAttribute("[NUnit.Framework.CategoryAttribute(«Units2»)]")]
        [NUnit.Framework.CategoryAttribute("Units2")]
        public virtual void Unit1()
        {
            string[] tagsOfScenario = new string[] {
                    "[NUnit.Framework.CategoryAttribute(«Units2»)]",
                    "Units2"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Unit 1", null, new string[] {
                        "[NUnit.Framework.CategoryAttribute(«Units2»)]",
                        "Units2"});
#line 4
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 6
 testRunner.Given("I have entered:", @"1 Comply with their duties and obligations as defined in the Health and Safety at Work Act
2 Demonstrate their understanding of their duties and obligations to health and safety by:
3 Present themselves in the workplace suitably prepared for the activities to be undertaken
4 Follow organisational accident and emergency procedures
5 Comply with emergency requirements, to include:
6 Recognise and control hazards in the workplace", ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 15
 testRunner.When("parse", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 17
 testRunner.Then("the lines should be correctly", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Unit 2")]
        public virtual void Unit2()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Unit 2", null, ((string[])(null)));
#line 18
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 20
 testRunner.Given("I have entered:", "Unit dafdfasdfa\r\n1 asdkjfakjsdfakjsdf\r\n2  asdfasdfa all of the following:\r\n2.1 on" +
                        "e of the following: ad;lsfakdhldasfkja aasdhflasd\r\n2.2 alsdefaksdhfas plus", ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 28
 testRunner.When("parse", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 30
 testRunner.Then("the line should be have message: 5", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Unit 3")]
        public virtual void Unit3()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Unit 3", null, ((string[])(null)));
#line 31
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 32
     testRunner.Given("I have entered:", @"1.10 Carry out all of the following during the fault diagnostic activities:  
1.10.1 plan the fault diagnostic activities prior to beginning the work   
1.10.2 use the correct issue of company and/or manufacturers’ drawings and maintenance documentation  
1.10.3 adhere to procedures or systems in place for risk assessment, COSHH, personal protective equipment and other relevant safety regulations  
1.10.4 ensure the safe isolation of equipment (such as mechanical, electricity, gas, air or fluids)  
1.10.5 provide safe access and working arrangements for the maintenance area  
1.10.6 carry out the fault diagnostic activities, using approved procedures  
1.10.7 collect equipment fault diagnostic evidence from live and isolated systems  
1.10.8 disconnect or isolate components or parts of the system, when appropriate, to confirm the diagnosis 
1.10.9 identify the fault, and determine appropriate corrective action   
1.10.10 dispose of waste items in a safe and environmentally acceptable manner, and leave the work area in a safe condition   ", ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 46
 testRunner.When("parse", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 48
 testRunner.Then("the lines should be correctly", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Unit 4")]
        public virtual void Unit4()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Unit 4", null, ((string[])(null)));
#line 49
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 50
     testRunner.Given("I have entered:", "2 Know how to comply with statutory regulations and organisational safety require" +
                        "ments\r\n2.1 Describe the roles and responsibilities of themselves and others unde" +
                        "r the Health and Safety at Work Act, and other current legislation (such as The " +
                        "Management of Health and Safety at Work Regulations, Workplace Health and Safety" +
                        " and Welfare Regulations, Personal Protective Equipment at Work Regulations, Man" +
                        "ual Handling Operations Regulations, Provision and Use of Work Equipment Regulat" +
                        "ions, Display Screen at Work Regulations, Reporting of Injuries, Diseases and Da" +
                        "ngerous Occurrences Regulations) \r\n2.2 Describe the specific regulations and saf" +
                        "e working practices and procedures that apply to their work activities \r\n2.3 Des" +
                        "cribe the warning signs for the seven main groups of hazardous substances define" +
                        "d by Classification, Packaging and Labelling of Dangerous Substances Regulations" +
                        " \r\n2.4 Explain how to locate relevant health and safety information for their ta" +
                        "sks, and the sources of expert assistance when help is needed \r\n2.5 Explain what" +
                        " constitutes a hazard in the workplace (such as moving parts of machinery, elect" +
                        "ricity, slippery and uneven surfaces, poorly placed equipment, dust and fumes, h" +
                        "andling and transporting, contaminants and irritants, material ejection, fire, w" +
                        "orking at height, environment, pressure/stored energy systems, volatile, flammab" +
                        "le or toxic materials, unshielded processes, working in confined spaces) \r\n2.6 D" +
                        "escribe their responsibilities for identifying and dealing with hazards and redu" +
                        "cing risks in the workplace  \r\n2.7 Describe the risks associated with their work" +
                        "ing environment (such as the tools, materials and equipment that they use, spill" +
                        "ages of oil, chemicals and other substances, not reporting accidental breakages " +
                        "of tools or equipment and not following laid-down working practices and procedur" +
                        "es) \r\n2.8 Describe the processes and procedures that are used to identify and ra" +
                        "te the level of risk (such as safety inspections, the use of hazard checklists, " +
                        "carrying out risk assessments, COSHH assessments) \r\n2.9 Describe the first aid f" +
                        "acilities that exist within their work area and within the organisation in gener" +
                        "al; the procedures to be followed in the case of accidents involving injury \r\n2." +
                        "10 Explain what constitute dangerous occurrences and hazardous malfunctions, and" +
                        " why these must be reported even if no-one is injured ", ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 64
 testRunner.When("parse", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 66
 testRunner.Then("the line should be have message: 7", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Unit 5")]
        public virtual void Unit5()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Unit 5", null, ((string[])(null)));
#line 67
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 68
     testRunner.Given("I have entered:", @"8 The apprentice will be required to use at least six of the following measuring equipment during the hand fitting and checking activities: • external micrometers • surface finish equipment (such as comparison plates, machines) • vernier calliper • rules • feeler gauges • squares • bore/hole gauges • callipers • slip gauges • protractors • radius/profile gauges • depth micrometers • thread gauges • depth verniers • dial test indicators (DTI) • coordinate measuring machine (CMM) 
9 The apprentice will be required to produce a component that meets all of the following standards, as applicable to the process: • components to be free from false tool cuts, burrs and sharp edges • general dimensional tolerance +/- 0.25mm or +/- 0.010” • there must be one or more specific dimensional tolerances within +/- 0.1mm or +/- 0.004” Plus at least one more of the following: • flatness and squareness 0.05mm per 25mm or 0.002″ per inch • angles within +/- 1 degree • screw threads to BS Medium fit • reamed within H8 • surface finish 63 μin or 1.6 μm
Unit FPGA-02: Maintaining Mechanical Devices and Equipment", ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 74
 testRunner.When("parse", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 76
 testRunner.Then("the lines should be correctly", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Unit 6")]
        public virtual void Unit6()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Unit 6", null, ((string[])(null)));
#line 77
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 78
     testRunner.Given("I have entered:", "1.11 Produce drawings which comply with one or more of the following:   a) organi" +
                        "sational guidelines   b) statutory regulations and codes of practice    c) CAD s" +
                        "oftware standards   d) BS and ISO standards   e) other international standard   " +
                        "", ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 82
 testRunner.When("parse", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 84
 testRunner.Then("the lines should be correctly", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
