Feature: Rover
A mars rover that navigates on a grid.

    @Acceptance
    Scenario: Rover should start at position 0:0 facing north
        Given rover is initialized
        Then the X coordinate should be 0
        And the Y coordinate should be 0
        And the direction should be "N"