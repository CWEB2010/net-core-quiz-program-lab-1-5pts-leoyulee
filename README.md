# .NET Core Quiz Program (Lab 1)

This is a quiz application that allows the owner of the quiz to have any number of questions and answers in multiple choice form. By default, it is configured to have questions on .NET Core with four answers.

## User Documentation
### Controls
This quiz comes with two sets of controls:
  - Controls for Yes/No Questions
  - Controls for Multiple Choice Questions

Generally, the buttons you need to press will be explicitly stated after a question. However, there are programmed controls of which perform the same function under the context the set of controls being used, which is shown below.

#### Controls for Yes/No Questions
No:
- N
- X
- Keyboard 0
- Numpad 0

Yes:
- Y
- Z
- Keyboard 1
- Numpad 1

#### Controls for Multiple Choice Questions
Exit:
- N
- X
- Keyboard 0
- Numpad 0

Option 1 (A)
- A
- J
- Keyboard 1
- Numpad 1

Option 2 (B)
- B
- K
- Keyboard 2
- Numpad 2

Option 3 (C)
- C
- L
- Keyboard 3
- Numpad 3

Option 4 (D)
- D
- ";" Key
- Keyboard 4
- Numpad 4

### Interface

The quiz comes with a small amount of customization. At the beginning of a quiz session, the user will be prompted asking if they would want to take the quiz, followed by a prompt asking for whether or not they would like the quiz to display if their latest answer was correct, along side a percentage value of their current score.

### Usage

The primary usage of this quiz is to review some of the .NET Core's functionality and history. A secondary use would to use this application as a template for other quizzes by modifying the variables, which is explained in the next part of the documentation.

This program runs similarly to other quiz programs, with the exception of the quiz automatically submitting the user's answer once one of the hotkeys are pressed. If there is enough demand, this can be changed.

## Owner Documentation

This section is here to describe what changes a future owner can do to customize this quiz for their own use. If you're only changing a few variables, please credit the creation of the program to Leo Lee, the original creator.

### Variables

All "global" variables that is critical for the functionality of this application are placed in the beginning of the code. Here, you can change the keys that users press to answer questions, alongside the questions, multiple choice answers and the answer key.	
### Debugging

By default, the debug boolean is set to false. However, this can be changed by either editing the code or pressing "Delete" when the application is running. When this is enabled, the program will print out when it progresses to a new segment of the quiz and all of the keys that are pressed, alongside other values that are used within the code. 

Having the debug boolean to equal "true" will disable the Easter Egg.

### Easter Egg

This quiz comes with an Easter Egg that is on by default, and cannot turn off unless "debug" mode is on.

The Easter Egg has a 1 in 5 chance of occurring when the user closes the program with a sentinel key. When it does enable, the application will prompt a message. If that message is followed by a "Yes", **it will shut down the user's computer.**

Thus, be vigilant.

## Developer Documentation
**WIP**