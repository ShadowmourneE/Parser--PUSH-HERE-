Feature: Units2
@[NUnit.Framework.CategoryAttribute(«Units2»)]
@Units2
Scenario: Unit 1
    
	Given I have entered:
                         """
                         1 Comply with their duties and obligations as defined in the Health and Safety at Work Act
                         2 Demonstrate their understanding of their duties and obligations to health and safety by:
                         3 Present themselves in the workplace suitably prepared for the activities to be undertaken
                         4 Follow organisational accident and emergency procedures
                         5 Comply with emergency requirements, to include:
                         6 Recognise and control hazards in the workplace
                         """
	When parse
    #correctly p.1.3
	Then the lines should be correctly 
Scenario: Unit 2
    
	Given I have entered:
                         """
                         Unit dafdfasdfa
                         1 asdkjfakjsdfakjsdf
                         2  asdfasdfa all of the following:
                         2.1 one of the following: ad;lsfakdhldasfkja aasdhflasd
                         2.2 alsdefaksdhfas plus
                         """
	When parse
    #correctly p.1.3
	Then the line should be have message: 5
Scenario: Unit 3
     Given I have entered:
                         """
                         1.10 Carry out all of the following during the fault diagnostic activities:  
                         1.10.1 plan the fault diagnostic activities prior to beginning the work   
                         1.10.2 use the correct issue of company and/or manufacturers’ drawings and maintenance documentation  
                         1.10.3 adhere to procedures or systems in place for risk assessment, COSHH, personal protective equipment and other relevant safety regulations  
                         1.10.4 ensure the safe isolation of equipment (such as mechanical, electricity, gas, air or fluids)  
                         1.10.5 provide safe access and working arrangements for the maintenance area  
                         1.10.6 carry out the fault diagnostic activities, using approved procedures  
                         1.10.7 collect equipment fault diagnostic evidence from live and isolated systems  
                         1.10.8 disconnect or isolate components or parts of the system, when appropriate, to confirm the diagnosis 
                         1.10.9 identify the fault, and determine appropriate corrective action   
                         1.10.10 dispose of waste items in a safe and environmentally acceptable manner, and leave the work area in a safe condition   
                         """
	When parse
    #correctly p.1.3
	Then the lines should be correctly
Scenario: Unit 4
     Given I have entered:
                         """
2 Know how to comply with statutory regulations and organisational safety requirements
2.1 Describe the roles and responsibilities of themselves and others under the Health and Safety at Work Act, and other current legislation (such as The Management of Health and Safety at Work Regulations, Workplace Health and Safety and Welfare Regulations, Personal Protective Equipment at Work Regulations, Manual Handling Operations Regulations, Provision and Use of Work Equipment Regulations, Display Screen at Work Regulations, Reporting of Injuries, Diseases and Dangerous Occurrences Regulations) 
2.2 Describe the specific regulations and safe working practices and procedures that apply to their work activities 
2.3 Describe the warning signs for the seven main groups of hazardous substances defined by Classification, Packaging and Labelling of Dangerous Substances Regulations 
2.4 Explain how to locate relevant health and safety information for their tasks, and the sources of expert assistance when help is needed 
2.5 Explain what constitutes a hazard in the workplace (such as moving parts of machinery, electricity, slippery and uneven surfaces, poorly placed equipment, dust and fumes, handling and transporting, contaminants and irritants, material ejection, fire, working at height, environment, pressure/stored energy systems, volatile, flammable or toxic materials, unshielded processes, working in confined spaces) 
2.6 Describe their responsibilities for identifying and dealing with hazards and reducing risks in the workplace  
2.7 Describe the risks associated with their working environment (such as the tools, materials and equipment that they use, spillages of oil, chemicals and other substances, not reporting accidental breakages of tools or equipment and not following laid-down working practices and procedures) 
2.8 Describe the processes and procedures that are used to identify and rate the level of risk (such as safety inspections, the use of hazard checklists, carrying out risk assessments, COSHH assessments) 
2.9 Describe the first aid facilities that exist within their work area and within the organisation in general; the procedures to be followed in the case of accidents involving injury 
2.10 Explain what constitute dangerous occurrences and hazardous malfunctions, and why these must be reported even if no-one is injured 
                         """
	When parse
    #correctly p.1.3
	Then the line should be have message: 7
Scenario: Unit 5
     Given I have entered:
                         """
8 The apprentice will be required to use at least six of the following measuring equipment during the hand fitting and checking activities: • external micrometers • surface finish equipment (such as comparison plates, machines) • vernier calliper • rules • feeler gauges • squares • bore/hole gauges • callipers • slip gauges • protractors • radius/profile gauges • depth micrometers • thread gauges • depth verniers • dial test indicators (DTI) • coordinate measuring machine (CMM) 
9 The apprentice will be required to produce a component that meets all of the following standards, as applicable to the process: • components to be free from false tool cuts, burrs and sharp edges • general dimensional tolerance +/- 0.25mm or +/- 0.010” • there must be one or more specific dimensional tolerances within +/- 0.1mm or +/- 0.004” Plus at least one more of the following: • flatness and squareness 0.05mm per 25mm or 0.002″ per inch • angles within +/- 1 degree • screw threads to BS Medium fit • reamed within H8 • surface finish 63 μin or 1.6 μm
Unit FPGA-02: Maintaining Mechanical Devices and Equipment
                         """
	When parse
    #correctly p.1.3
	Then the lines should be correctly
Scenario: Unit 6
     Given I have entered:
                         """
                         1.11 Produce drawings which comply with one or more of the following:   a) organisational guidelines   b) statutory regulations and codes of practice    c) CAD software standards   d) BS and ISO standards   e) other international standard   
                         """
	When parse
    #correctly p.1.3
	Then the lines should be correctly
   