# Document Request System

A desktop application built with **C# (.NET Windows Forms)** for managing and processing student document requests in a school environment.

---

## Disclaimer

This system was developed **for academic purposes only** as part of a school project.

The names, workflows, and documents represented in this application are used only for demonstration and simulation.
They **do not represent or reflect the official systems, policies, or procedures of any real university or institution**.

Any resemblance to real systems is purely for the purpose of creating a realistic academic project environment.

---

## Overview

The Document Request System allows students to submit requests for school documents such as Certificates of Grades.
Administrators can review, approve, process, and update the status of these requests through a centralized dashboard.

---

## Features

* Student document request submission
* Administrative dashboard for request management
* Request status tracking
  *(Processing → Approved → Ready for Pickup)*
* Notification system for request updates
* SQLite database integration
* User authentication with role separation

---

## Technologies Used

* **C#**
* **.NET Windows Forms**
* **SQLite**
* **Visual Studio**
* **Git & GitHub**

---

## Project Structure

```
document-request-system-project
│
├ Image assets/        → icons and visual resources
├ database/            → database related files and helpers
├ Properties/          → project configuration and resources
│
├ AdminDashboard.cs
├ Login.cs
├ Main Form.cs
├ DatabaseHelper.cs
├ DatabaseInitializer.cs
├ App.config
└ Document Request System Project.csproj
```

---

## How to Run

1. Clone the repository
2. Open the project in **Visual Studio**
3. Build the solution
4. Run the application

---

## Test Access

For demonstration purposes:

**Default accounts**

```
admin1     / 1234
student1   / 1234
```

**Developer account creation**

Press:

```
CTRL + SHIFT + D
```

on the login screen and enter:

```
99999
```

---

## Purpose

This project was created as part of an **academic requirement** and demonstrates fundamental concepts in:

* Desktop application development
* Event-driven programming
* Database integration
* UI design
* Request workflow management

---

## Author

**kairusphere**
