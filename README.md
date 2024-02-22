
# Ask Me Your Task V2

This web API provides essential features for a task management web app.


## Tech Stack

**Client:** ReactJS

**Server:** ASP.NET Core Minimal API, EF Core, MySQL


## API Reference

### Schemas

#### TodoDto
| Property | Type     | 
| :-------- | :------- | 
| `id`      | `string` | 
| `title`      | `string` | 
| `description`      | `string` | 
| `completed`      | `bool` | 
| `important`      | `bool` | 
| `priority`      | `int` | 

#### TodoListDto
| Property | Type     | 
| :-------- | :------- | 
| `id`      | `string` | 
| `title`      | `string` | 
| `color`      | `string` | 
| `todos`      | `Enumerable<TodoDto>` | 


### Get all TodoList

```http
  GET /api/todoLists/get
```
Return an Enumerable of all TodoList objects

### Add new Todo

```http
  POST /api/todos/add
```
Add a new Todo to the selected TodoList 

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `listId`      | `string` | **(Required)** Id of the TodoList being modified |
| `todo`      | `TodoDto` | **(Required)** New todo |

### Add new TodoList

```http
  POST /api/todoLists/add
```
Add a new TodoList 

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `todoList`      | `TodoListDto` | **(Required)** New todo list |

### Update a Todo's complete state

```http
  PUT /api/todos/update/complete
```
Set the selected Todo to be completed
| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | **(Required)** Id of the Todo |


### Update a Todo's important state

```http
  PUT /api/todos/update/important
```
Set the selected Todo's important state
| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | **(Required)** Id of the Todo |
| `isImportant`      | `bool` | **(Required)**  |

### Update a Todo's priority state

```http
  PUT /api/todos/update/priority
```
Set the numerical order of the Todo in a TodoList
| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | **(Required)** Id of the Todo |
| `priority`      | `int` | **(Required)** The numerical order (0 is the highest priority) |


### Update a TodoList's color theme

```http
  PUT /api/todoLists/update/color
```
Set the color theme for the TodoList. This will also set the color of the Todo objects belong to the selected TodoList
| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | **(Required)** Id of the TodoList |
| `colorHex`      | `string` | **(Required)** Hex representation of the color |

### Delete a TodoList

```http
  DELETE /api/todoList/delete
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | **Required**. Id of the TodoList |




