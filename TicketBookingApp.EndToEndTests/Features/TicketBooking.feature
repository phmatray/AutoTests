Feature: Ticket Booking System
As a user,
I want to view available events and book tickets,
So that I can attend an event.

Scenario: Home page lists available events
    Given I navigate to the home page
    Then I should see a list of events

Scenario: Event details are displayed correctly
    Given I navigate to the event details page for event with id 1
    Then I should see the event title "Rock Concert"

Scenario: Booking a ticket successfully
    Given I navigate to the booking page for event with id 1
    When I enter "John Doe" into the "User Name" field
    And I click on "Confirm Booking"
    Then I should see a confirmation message "Booking Confirmed"