@Sprint3
@PostsSteps
Feature: GetPosts
As a non-authenticated user,
I want the ability to get a post.

  @AcceptanceCriteria
  Scenario: A non-authenticated user successfully gets a post
     When a non-authenticated user sends a request to get a post
     Then the service's response is "OK"
	  And the service returns the specific post

  @NegativePath
  Scenario: A non-authenticated user attempts to get a post with nonexistent id
     When a non-authenticated user sends a request to get a nonexistent post
     Then the service's response is "NotFound"