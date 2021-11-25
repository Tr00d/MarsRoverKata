Feature: Rover
A mars rover that navigates on a grid.

    @Acceptance
    Scenario: Rover should start at position 0:0 facing north
        Given rover is initialized
        Then the X coordinate should be 0
        And the Y coordinate should be 0
        And the direction should be "N"

    @Acceptance
    Scenario: Given a grid with no obstacles, input "MMRMMLM" gives position 2:3 facing north
        Given rover is initialized
        When rover receives input "MMRMMLM"
        Then the X coordinate should be 2
        And the Y coordinate should be 3
        And the direction should be "N"

    @Acceptance
    Scenario: Given a grid with no obstacles, input "MMMMMMMMMM" gives position 0:0 facing north (due to wrap-around)
        Given rover is initialized
        When rover receives input "MMMMMMMMMM"
        Then the X coordinate should be 0
        And the Y coordinate should be 0
        And the direction should be "N"