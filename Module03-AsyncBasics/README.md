# Module 03 - Async Basics

Homework:

- Create a method that will try to get a response from a given `url`, retrying `maxTries` number of times.
- It should wait one second before the second try, and double the wait time before every successive retry (so pauses before retries will be 1, 2, 4, 8, ... seconds).
- `maxTries` must be at least 2
- We retry if:
  - we get non-successful status code (outside of 200-299 range), or
  - HTTP call thrown an exception (like network connectivity or DNS issue)
- Token should be able to cancel both HTTP call and the retry delay
- If all retries fails, the method should throw the exception of the last try

![image](https://github.com/br1code/asyncexpert-course/assets/17786059/f2d1b74d-09b0-40a0-890a-ad5e85e6f71a)
