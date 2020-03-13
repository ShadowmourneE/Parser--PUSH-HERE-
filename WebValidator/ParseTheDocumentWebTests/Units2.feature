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
	Then all lines should be correctly 
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
	Then the line 5 should have message: Incorrect string
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
	Then all lines should be correctly
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
	Then the line 8 should have message: Check this line
Scenario: Unit 5
     Given I have entered:
                         """
8 The apprentice will be required to use at least six of the following measuring equipment during the hand fitting and checking activities: • external micrometers • surface finish equipment (such as comparison plates, machines) • vernier calliper • rules • feeler gauges • squares • bore/hole gauges • callipers • slip gauges • protractors • radius/profile gauges • depth micrometers • thread gauges • depth verniers • dial test indicators (DTI) • coordinate measuring machine (CMM) 
9 The apprentice will be required to produce a component that meets all of the following standards, as applicable to the process: • components to be free from false tool cuts, burrs and sharp edges • general dimensional tolerance +/- 0.25mm or +/- 0.010” • there must be one or more specific dimensional tolerances within +/- 0.1mm or +/- 0.004” Plus at least one more of the following: • flatness and squareness 0.05mm per 25mm or 0.002″ per inch • angles within +/- 1 degree • screw threads to BS Medium fit • reamed within H8 • surface finish 63 μin or 1.6 μm
Unit FPGA-02: Maintaining Mechanical Devices and Equipment
                         """
	When parse
	Then all lines should be correctly
Scenario: Unit 6
     Given I have entered:
                         """
                         1.11 Produce drawings which comply with one or more of the following:   a) organisational guidelines   b) statutory regulations and codes of practice    c) CAD software standards   d) BS and ISO standards   e) other international standard   
                         """
	When parse
	Then all lines should be correctly
Scenario: Unit 7
     Given I have entered:
                         """
2 Understand how to Determine Welding and Related Technical Requirements to Achieve Objectives 
2. 1 Explain the specific safety precautions to be taken when working in a welding and related environment (such as specific legislation or regulations governing the activities or work area, safe working practices and procedures to be adopted, general workshop and site safety practice, risk assessment procedures and relevant requirements of HASAWA, COSHH and Work Equipment Regulations)  
2. 2 Explain the personal protective clothing and equipment that should be worn (such as eye protection, ear and head  protection) 
                         """
	When parse
	Then the line 2 should have message: Nesting does't match previous
Scenario: Unit 8
    Given I have entered:
                         """
                         1.4 Set standards and guidelines for situations where information, resources or equipment is missing or is in surplus and where improvements can be made
                         """
	When parse
	Then all lines should be correctly
Scenario: Unit 9
    Given I have entered:
                         """
1 Work safely at all times, complying with health and safety and other relevant regulations, directives and guidelines   
2 Lead a maintenance team by carrying out all the following:   a) communicate the maintenance activities to the team   b) involve the team in planning how the maintenance activities will be undertaken   c) allocate specific maintenance activities to each team member    d) involve the team in identifying improvements that could be made to the maintenance process and/or procedures    e) encourage the team and/or individuals to take the lead where appropriate   
3 Produce and update relevant maintenance schedules and plans    
4 Review and update maintenance procedures and plans to include three the following:   a) preventive maintenance (routine inspections, and adjustments)   b) corrective maintenance (activities identified from preventative maintenance activities)   c) predictive maintenance (analysis of the equipment’s condition)   d) reactive maintenance (unexpected equipment/component failure)   e) maintenance prevention (equipment/component design and development)   plus supporting documentation associated with two of the following   f) equipment performance   g) equipment downtime/failure   h) overall equipment effectiveness (OEE)   i) maintenance costs   j) health and safety   k) staff development and training   l) maintenance procedures/instructions   m) operator manuals/working instructions   n) regulatory compliance   
5 Lead maintenance activities within the limits of their personal authority   
6 Carry out the maintenance activities in the specified sequence and in an agreed timescale
                         """
	When parse
	Then the line 2 should have message: Line in the wrong format for children
Scenario: Unit 10
    Given I have entered:
                         """
1 Work safely at all times, complying with health and safety and other relevant regulations, directives and guidelines   
2 Lead a maintenance team by carrying out all the following:
2.1 communicate the maintenance activities to the team 
                         """
	When parse
	Then all lines should be correctly
Scenario: Unit 11
    Given I have entered:
                         """
1.7 Identify the hazards and risks that are associated with the following: a) their working environment b) the equipment that they use c) materials and substances (where appropriate) that they use d) working practices that do not follow laid-down procedures
                         """
	When parse
	Then all lines should be correctly
Scenario: Unit 12
    Given I have entered:
                         """
1.3 Determine organisational availability of in-house equipment against the planned manufacturing layout to include both of the following: a) shared existing resource b) freely available resource
                         """
	When parse
	Then the line 1 should have message: Incorrect string
Scenario: Unit 13
    Given I have entered:
                         """
2 Lead a maintenance team by carrying out all the following:   a) communicate the maintenance activities to the team   b) involve the team in planning how the maintenance activities will be undertaken   c) allocate specific maintenance activities to each team member    d) involve the team in identifying improvements that could be made to the maintenance process and/or procedures    e) encourage the team and/or individuals to take the lead where appropriate   
                         """
	When parse
	Then the line 1 should have message: Incorrect string
Scenario: Unit 14
    Given I have entered:
                         """
1.5 Comply with emergency requirements, to include: a) identifying the appropriate qualified first aiders and the location of first aid facilities b) identifying the procedures to be followed in the event of injury to themselves or others c) following organisational procedures in the event of fire and the evacuation of premises d) identifying the procedures to be followed in the event of dangerous occurrences or hazardous malfunctions of equipment
                         """
	When parse
	Then all lines should be correctly
Scenario: Unit 15
    Given I have entered:
                         """
1.8 Use appropriate dismantling and re-assembly techniques to deal with three of the following technologies: Mechanical equipment: Carry out all of the following: a) draining and replenishing fluids b) removing and refitting/replacing locking and retaining devices c) proof marking components to aid reassembly d) removing and refitting minor mechanical units/sub-assemblies (such as guards, cover plates, pulleys and belts) e) removing and refitting major mechanical components (such as shafts, gear mechanisms, bearings, clutches) f) replacing lifed items (such as filters, oils/lubricants) g) setting, aligning and adjusting replaced units Electrical equipment: Carry out all of the following: a) isolating the power supply b) disconnecting and reconnecting wires/cables c) removing and replacing minor electrical components (such as relays, sensing devices, limit switches) d) removing and replacing major electrical components (such as motors, switch/control gear) e) attaching cable end fittings (such as crimped and soldered) f) making de-energised checks before powering up Fluid power equipment: Carry out all of the following: a) chocking/supporting cylinders/rams/components b) releasing stored pressure c) removing and replacing hoses/pipes d) removing and replacing minor or lifted components (such as filters, gaskets, dust seals) e) removing and replacing major components (such as pumps, cylinders, valves, actuators) f) setting and adjusting replaced components g) making de-energised checks before re-pressurising the system Programmable controller based equipment: Carry out all of the following: a) de-activating and resetting program controller b) disconnecting and reconnecting wires/cables c) removing and replacing input/output interfacing d) removing and replacing program logic peripherals e) checking and reviewing program format and content f) editing programs using the correct procedure (where appropriate) Process instrumentation: Carry out all of the following: a) isolating instruments/sensing devices b) disconnecting supply/signal connections c) removing and replacing instruments in the system d) replacing all ‘lifed’ items (such as seals, gaskets, dust covers) e) re-connecting instrumentation pipework and power supply f) checking that signal transmission is satisfactory Electronic equipment: Carry out all of the following: a) isolating equipment from the power supply b) dismantling/disconnecting equipment to the required level c) disconnecting and reconnecting wires and cables d) removing and replacing electronic units/circuit boards e) removing and replacing electronic components f) soldering and de-soldering g) making de-energised checks before powering up;
                         """
	When parse
    Then the line 1 should have message: Incorrect string
Scenario: Unit 16
    Given I have entered:
                         """
11 Use four of the following types of test equipment to aid fault diagnosis: a) multimeter b) pressure sources c) oscilloscope d) digital pressure indicators e) signal sources/generator f) standard test gauges g) current injection devices h) special purpose test equipment i) logic probe j) signal tracer k) other specific test equipment;
                         """
	When parse
    Then all lines should be correctly
Scenario: Unit 17
    Given I have entered:
                         """
12 Find faults that have resulted in two of the following breakdown categories: a) intermittent problem b) partial failure/out-of-specification output c) complete breakdowns
                         """
	When parse
    Then all lines should be correctly
Scenario: Unit 18
    Given I have entered:
                         """
11 Use four of the following types of test equipment to aid fault diagnosis: a) multimeter b) pressure sources c) oscilloscope d) digital pressure indicators e) signal sources/generator f) standard test gauges g) current injection devices h) special purpose test equipment i) logic probe j) signal tracer k) other specific test equipment
12 Find faults that have resulted in two of the following breakdown categories: a) intermittent problem b) partial failure/out-of-specification output c) complete breakdowns
                         """
	When parse
    Then all lines should be correctly
Scenario: Unit 19
    Given I have entered:
                         """
12 Find faults that have resulted in two of the following breakdown categories: a) intermittent problem b) partial failure/out-of-specification output c) complete breakdowns
                         """
	When parse
    Then all lines should be correctly
Scenario: Unit 20
    Given I have entered:
                         """
1.18 Produce welded joints which meet all of the following (with reference to BS 4872 Part 1 Weld test requirements):  
1.18.1 welds meet the required dimensional accuracy 
1.18.2 fillet welds are equal in leg length and slightly convex in profile, with the size of the fillet equivalent to the thickness of the material welded
                         """
	When parse
    Then all lines should be correctly
      
  