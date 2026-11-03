Feature: Group Pre-Order Participants (Direction 1)
  As a group order owner or guest
  I want to view the list of participants in a group pre-order
  So that I can see everyone's selected dishes and total amount

  @api @direction1
  Scenario: Get group pre-order participants without valid token returns forbidden
    Given a group pre-order exists with ID "test-group-123"
    When the user requests the group details via API
    Then the response status code should be 403

  @api @direction1
  Scenario: Get group pre-order for non-existent group returns 403
    Given a non-existent group ID "invalid-group-9999"
    When the user requests the group details via API
    Then the response status code should be 403