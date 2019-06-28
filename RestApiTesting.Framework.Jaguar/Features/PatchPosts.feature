@Sprint5
@PostsSteps
Feature: PatchPosts
As a non-authenticated user,
I want the ability to update a post.

  @AcceptanceCriteria
  Scenario: A non-authenticated user successfully patches a post
     When a non-authenticated user sends a request to patch a post
     Then the service's response is "OK"
	  And the service returns the patched post

  @NegativePath
  Scenario: A non-authenticated user attempts to patch a post with nonexistent id
     When a non-authenticated user sends a request to patch a nonexistent post
     Then the service's response is "OK"
	  And the service returns the patched post
