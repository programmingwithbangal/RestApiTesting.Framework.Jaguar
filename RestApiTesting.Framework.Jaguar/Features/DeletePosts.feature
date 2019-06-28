@Sprint4
@PostsSteps
Feature: DeletePosts
As a non-authenticated user,
I want the ability to delete a post.

  @AcceptanceCriteria
  Scenario: A non-authenticated user successfully deletes a post
     When a non-authenticated user sends a request to delete a post
     Then the service's response is "OK"
	  And the service returns the empty post

  @NegativePath
  Scenario: A non-authenticated user attempts to delete a post with nonexistent id
     When a non-authenticated user sends a request to delete a nonexistent post
     Then the service's response is "OK"
	  And the service returns the empty post