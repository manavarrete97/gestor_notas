# API Documentation: Gestor Notas

## Base URL
The base URL for the API is:
```
http://localhost:5000/api
```
Replace `5000` with the actual port where the API is running.

---

## Endpoints

###1. **Estudiante**

#### **GET** `/Estudiante`
- **Description**: Retrieves a list of all students or a specific student by ID.
- **Query Parameters**:
 - `id` (optional): The ID of the student to retrieve.
- **Response**:
 - If `id` is provided, returns the student with the specified ID.
 - If `id` is not provided, returns all students.
- **Example**:
 - Request: `GET http://localhost:5000/api/Estudiante`
 - Request: `GET http://localhost:5000/api/Estudiante?id=1`

#### **POST** `/Estudiante`
- **Description**: Adds a new student.
- **Body**:
```json
{
 "nombre": "Juan Perez"
}
```
- **Response**: Confirmation message.
- **Example**:
 - Request: `POST http://localhost:5000/api/Estudiante`

#### **PUT** `/Estudiante`
- **Description**: Updates an existing student.
- **Body**:
```json
{
 "id":1,
 "nombre": "Juan Perez"
}
```
- **Response**: Confirmation message.
- **Example**:
 - Request: `PUT http://localhost:5000/api/Estudiante`

#### **DELETE** `/Estudiante`
- **Description**: Deletes a student by ID.
- **Query Parameters**:
 - `id`: The ID of the student to delete.
- **Response**: Confirmation message.
- **Example**:
 - Request: `DELETE http://localhost:5000/api/Estudiante?id=1`

---

###2. **Materia**

#### **GET** `/Materia`
- **Description**: Retrieves a list of all subjects or a specific subject by ID.
- **Query Parameters**:
 - `id` (optional): The ID of the subject to retrieve.
- **Response**:
 - If `id` is provided, returns the subject with the specified ID.
 - If `id` is not provided, returns all subjects.
- **Example**:
 - Request: `GET http://localhost:5000/api/Materia`
 - Request: `GET http://localhost:5000/api/Materia?id=1`

#### **POST** `/Materia`
- **Description**: Adds a new subject.
- **Body**:
```json
{
 "nombre": "Matemáticas",
 "idProfesor":1
}
```
- **Response**: Confirmation message.
- **Example**:
 - Request: `POST http://localhost:5000/api/Materia`

#### **PUT** `/Materia`
- **Description**: Updates an existing subject.
- **Body**:
```json
{
 "id":1,
 "nombre": "Matemáticas",
 "idProfesor":1
}
```
- **Response**: Confirmation message.
- **Example**:
 - Request: `PUT http://localhost:5000/api/Materia`

#### **DELETE** `/Materia`
- **Description**: Deletes a subject by ID.
- **Query Parameters**:
 - `id`: The ID of the subject to delete.
- **Response**: Confirmation message.
- **Example**:
 - Request: `DELETE http://localhost:5000/api/Materia?id=1`

---

###3. **Nota**

#### **GET** `/Nota`
- **Description**: Retrieves a specific grade by student ID and subject ID.
- **Query Parameters**:
 - `idEstudiante`: The ID of the student.
 - `idMateria`: The ID of the subject.
- **Response**: The grade details.
- **Example**:
 - Request: `GET http://localhost:5000/api/Nota?idEstudiante=1&idMateria=2`

#### **POST** `/Nota`
- **Description**: Adds a new grade.
- **Body**:
```json
{
 "nombre": "Examen Final",
 "idMateria":2,
 "idEstudiante":1,
 "valor":9.5
}
```
- **Response**: Confirmation message.
- **Example**:
 - Request: `POST http://localhost:5000/api/Nota`

#### **PUT** `/Nota`
- **Description**: Updates an existing grade.
- **Query Parameters**:
 - `idNota`: The ID of the grade to update.
 - `idProfesor`: The ID of the professor.
- **Body**:
```json
{
 "valor":8.5
}
```
- **Response**: Confirmation message.
- **Example**:
 - Request: `PUT http://localhost:5000/api/Nota?idNota=1&idProfesor=2`

#### **DELETE** `/Nota`
- **Description**: Deletes a grade by ID.
- **Query Parameters**:
 - `idNota`: The ID of the grade to delete.
 - `idProfesor`: The ID of the professor.
- **Response**: Confirmation message.
- **Example**:
 - Request: `DELETE http://localhost:5000/api/Nota?idNota=1&idProfesor=2`

#### **GET** `/Nota/details`
- **Description**: Retrieves detailed information about a specific grade.
- **Query Parameters**:
 - `idNota`: The ID of the grade to retrieve details for.
- **Response**: Detailed information about the grade, including associated student and subject.
- **Example**:
 - Request: `GET http://localhost:5000/api/Nota/details?idNota=1`

---

###4. **Profesor**

#### **GET** `/Profesor`
- **Description**: Retrieves a list of all professors or a specific professor by ID.
- **Query Parameters**:
 - `id` (optional): The ID of the professor to retrieve.
- **Response**:
 - If `id` is provided, returns the professor with the specified ID.
 - If `id` is not provided, returns all professors.
- **Example**:
 - Request: `GET http://localhost:5000/api/Profesor`
 - Request: `GET http://localhost:5000/api/Profesor?id=1`

#### **POST** `/Profesor`
- **Description**: Adds a new professor.
- **Body**:
```json
{
 "nombre": "Dr. Smith"
}
```
- **Response**: Confirmation message.
- **Example**:
 - Request: `POST http://localhost:5000/api/Profesor`

#### **PUT** `/Profesor`
- **Description**: Updates an existing professor.
- **Body**:
```json
{
 "id":1,
 "nombre": "Dr. John Smith"
}
```
- **Response**: Confirmation message.
- **Example**:
 - Request: `PUT http://localhost:5000/api/Profesor`

#### **DELETE** `/Profesor`
- **Description**: Deletes a professor by ID.
- **Query Parameters**:
 - `id`: The ID of the professor to delete.
- **Response**: Confirmation message.
- **Example**:
 - Request: `DELETE http://localhost:5000/api/Profesor?id=1`

---

## Notes
- Replace `localhost:5000` with the actual host and port where the API is running.
- Ensure that the required query parameters and body fields are provided for each request.
- For any issues or questions, refer to the API documentation or contact the development team.