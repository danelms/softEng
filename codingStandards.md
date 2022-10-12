# Coding Standards 😃

## Naming Conventions

PascalCase to be used for Class names e.g.,

- `RelationshipManager`

camelCase to be used for names of methods, functions and variables e.g.,

- `getName()` method
- `addItem()` function
- `customerName` variable

## Commenting

Comment header to feature at the top of each file, containing:
- Author(s)
- Date last updated

Control variables, e.g.  `i`, are not to be commented.

All other variables, e.g. `customerName, address`, etc., are to be commented with a concise description

Comments giving an overview of the functionality of a method or function to be written on the line directly above its signature e.g.,

`//This function does stuff` <br>
`functionName()`  <br>
`{`  <br>
`code;`  <br>
`}`  <br>

**No inline comments!**

## Structure / Organisation

Classes to be stored in separate files e.g., `RelationshipManager` and `Client`, for readability

Opening brackets for methods / functions to appear on the line immediately following that of their signature e.g.,

`methodName()`  <br>
**`{`**  <br>
`code;`  <br>
`}`  <br>

Within classes, group all methods together, and all functions together e.g.,

`functionName()`  <br>
`{`  <br>
`code;`  <br>
`}`  <br>

`functionName()`  <br>
`{`  <br>
`code;`  <br>
`}`  <br>

`methodName()`  <br>
`{`  <br>
`code;`  <br>
`}`  <br>

`methodName()`  <br>
`{`  <br>
`code;`  <br>
`}`  <br>
