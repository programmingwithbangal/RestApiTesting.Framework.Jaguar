@Sprint1
@PostsSteps
Feature: CreatePosts
As a non-authenticated user,
I want the ability to create a post.

  @AcceptanceCriteria
  Scenario: A non-authenticated user successfully creates a post
     When a non-authenticated user sends a request to create a post
     Then the service's response is "Created"
      And the service returns the newly created post
  
  
