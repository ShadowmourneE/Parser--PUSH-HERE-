Feature: Numbering
@[NUnit.Framework.CategoryAttribute(«Numbering»)]
@Numbering
Scenario: CheckRoot
    #current 1.1.1.3.1 prev 1.1.1.3 check 1.1.1.3==1.1.1.3
    Given I have entered:
                         """
                         1.1.1.3 bla bla bla
                         1.1.1.2.1 Work safely at all times, complying with health and safety legislation, regulations and other relevant guidelines
                         """
	When parse
	Then the line should be have message: line - 2. nesting does't match previous
Scenario: CheckNumberingPrev
    #current 1.1.1.4 prev 1.1.1.3.1 check 1.1.1 == 1.1.1 and 4>3
    Given I have entered:
                         """
                         1.1.1.3.1 bla bla bla
                         1.1.1.2 Work safely at all times, complying with health and safety legislation, regulations and other relevant guidelines
                         """
	When parse
	Then the line should be have message: line - 2. nesting does't match previous
Scenario: CheckNumberingCurrent
    #current 1.1.1.3.2 prev 1.1.1.3.1 check 1.1.1.3 == 1.1.1.3 and 2>1
    Given I have entered:
                         """
                         1.1.1.3.1 bla bla bla
                         1.1.1.3.1 Work safely at all times, complying with health and safety legislation, regulations and other relevant guidelines
                         """
	When parse
	Then the line should be have message: line - 2. nesting does't match previous
Scenario: CheckNumberingCurrent with Unit
    Given I have entered:
                         """
                         Unit Name
                         1.1.1.3.1 bla bla bla
                         1.1.1.3.1 Work safely at all times, complying with health and safety legislation, regulations and other relevant guidelines
                         """
	When parse
	Then the line should be have message: line - 3. nesting does't match previous