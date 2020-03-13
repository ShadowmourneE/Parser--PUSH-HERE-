Feature: Units
@[NUnit.Framework.CategoryAttribute(«Parse»)]
@Parse
Scenario: Unit 1
    
	Given I have entered:
                         """
                         1 bla bla bla
                         1.1 Work safely at all times, complying with health and safety legislation, regulations and other relevant guidelines
                         1.2 Demonstrate the required behaviours in line with the job role and company objectives
                         1.3 Carry out all of the following during the pipe bending, forming and fitting activities:
                         1.3.1 adhere to procedures or systems in place for risk assessment, COSHH, personal protective equipment (PPE) and other relevant safety regulations
                         1.3.2 follow job instructions, assembly drawings and procedures
                         1.3.3 check that the bending and forming equipment is in a safe and usable condition
                         1.3.4 return all tools and equipment to the correct location on completion of the pipe fitting activities
                         1.4 Plan the pipe fitting activities before they start them
                         1.5 Produce pipework assemblies using two of the following types of pipe: 1.5.1 carbon steel 1.5.2 copper 1.5.3 aluminium 1.5.4 stainless steel 1.5.5 brass 1.5.6 plastic
                         1.6 Mark out pipework, using the following method: 1.6.1 direct marking using tapes and markers Plus one more from the following 1.6.2 set-outs of pipework using templates 1.6.3 producing set wires 1.6.4 set-outs of pipework onto floor
                         """
	When parse
    #correctly p.1.3
	Then the lines should be correctly
Scenario: Unit 2
    Given I have entered:
                         """
                        1 Performance and Skills Requirements
                        1.1 work safely at all times, complying with health and safety legislation, regulations and other relevant guidelines
                        1.2 demonstrate the required behaviours in line with the job role and company objectives
                        1.3 wrong Ensure that they apply all of the following checks and practices at all times during the programming activities: 
                        1.4 Prepare and prove programs for one of the following types of CNC machine tool: a) two axis machine b) multiple axis machines (4 or more) c) three axis machine d) machining centres
                         """
	When parse
    #error p.1.3
	Then the line 4 should have message: Line in the wrong format for children
Scenario: Unit 3
    Given I have entered:
                         """
                         1.2 Carry out forming operations which produce components having all of the following shapes: 1.15.1 bends/upstands 1.15.2 tray/box sections 1.15.3 folds/safe edges 1.15.4 cylindrical sections Plus one more from the following: 1.15.5 wired edges 1.15.6 cowlings and rounded covers
                         1.3 Use both of the following types of forming equipment/techniques: 1.14.1 bending machine (hand or powered) 1.14.2 rolling machine (hand or powered) Plus two more from the following: 1.14.3 hammers/panel beating equipment 1.14.4 wheeling machine 1.14.5 stakes and formers 1.14.6 swaging machine 1.14.7 presses 1.14.8 shrinking techniques 1.14.9 jenny/wiring machine 1.14.10 stretching techniques
                         """
	When parse
    #correctly p. 1.2, 1.3 
	Then the lines should be correctly
Scenario: Unit 4
    Given I have entered:
                         """
                         1 Performance and Skills Requirements
                         1.1 work safely at all times, complying with health and safety legislation, regulations and other relevant guidelines
                         1.2 demonstrate the required behaviours in line with the job role and company objectives
                         1.3 Carry out all of the following during the instrumentation maintenance activities:1.3.1 adhere to procedures or systems in place for risk assessment, COSHH, personal protective equipment (PPE) and other relevant safety regulations 1.3.2 where appropriate, ensure the safe isolation of instruments (such as electrical, pneumatic, process) 1.3.3 follow job instructions, maintenance drawings and procedures 1.3.4 check that the tools and test instruments are within calibration date and are in a safe and usable condition 1.3.5 ensure that the equipment/system is kept free from foreign objects, dirt or other contamination 1.3.6 return all tools and equipment to the correct location on completion of the maintenance activities
                         1.3.1 adhere to procedures or systems in place for risk assessment, COSHH, personal protective equipment (PPE) and other relevant safety regulations
                         1.3.2 where appropriate, ensure the safe isolation of instruments (such as electrical, pneumatic, process)
                         1.3.3 follow job instructions, maintenance drawings and procedures
                         1.3.4 check that the tools and test instruments are within calibration date and are in a safe and usable condition
                         1.3.5 ensure that the equipment/system is kept free from foreign objects, dirt or other contamination
                         1.3.6 return all tools and equipment to the correct location on completion of the maintenance activities
                         """
	When parse
    #error  1.3
	Then the line 4 should have message: Incorrect string
Scenario: Unit 5
    Given I have entered:
                         """
                         1 Performance and Skills Requirements
                         1.1 both of the following: plus more of the following asdfasdfasdfasdf
                         """
	When parse
    #correctly all
	Then the lines should be correctly
