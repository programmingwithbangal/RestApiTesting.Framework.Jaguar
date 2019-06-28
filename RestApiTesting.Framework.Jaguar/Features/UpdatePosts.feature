@Sprint2
@PostsSteps
Feature: UpdatePosts
As a non-authenticated user,
I want the ability to update a post.

  @AcceptanceCriteria
  Scenario: A non-authenticated user successfully updates a post
     When a non-authenticated user sends a request to update a post
     Then the service's response is "OK"
	  And the service returns the updated post

  @NegativePath
  Scenario: A non-authenticated user attempts to update a post with nonexistent id
     When a non-authenticated user sends a request to update a nonexistent post
     Then the service's response is "InternalServerError"
