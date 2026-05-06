# GroupMe – Group Collaboration & Meeting Management

## 1. Project Overview

GroupMe is a console-based group collaboration application designed for academic settings. 
It allows students and instructors to organize groups, schedule meetings, take notes, and share files 
all from one place. Users are assigned roles (Member, GroupLeader, TA, Professor) that reflect their level of responsibility within a group.

**Core features:**
- Create and manage groups with role-based membership
- Schedule meetings of four types: Online, InPerson, Hybrid, and Call
- Create and store public or private meeting notes
- Upload and retrieve shared group files

**Assumptions & constraints:**
- All data is stored in memory
- The interface is console-only. 
- A single group is active per session.

---

## 2. Build & Run Instructions

**Tools & versions:**
- Language: C# (.NET 9.0)
- any .NET-compatible IDE / CLI)
- Build tool: `dotnet` CLI

**Steps to compile and run:**

```bash
# Clone or unzip the project, then navigate to the project root

# Restore dependencies

# Build the project

# Run the project

```

**Notes:**
- No command-line arguments are required.
- On launch the interactive menu starts.
- All input is entered via the keyboard

---

## 3. Required OOP Features

| OOP Feature | File Name | Line Numbers | Reasoning / Purpose |
|---|---|---|---|
| Inheritance – User → GroupMember | `User.cs`, `GroupMember.cs` | User: 3–26, GroupMember: 3–61 | `GroupMember` extends `User` to inherit common identity fields (UserID, Name, Email, Role) while adding group-specific behavior like joining groups and managing notes. |
| Inheritance – GroupMember → GroupLeader, TA, Professor | `GroupLeader.cs`, `TA.cs`, `Professor.cs` | All files, class declarations | Each role extends `GroupMember` to inherit base member behavior while adding role-specific methods such as `ApproveMeeting` (GroupLeader) and `AddMemberToGroup` (TA, Professor). |
| Inheritance – Meeting → subtypes | `Meeting.cs`, `OnlineMeeting.cs`, `InPersonMeeting.cs`, `HybridMeeting.cs`, `CallMeeting.cs` | Meeting: 3–41 | Abstract `Meeting` defines shared structure; each subtype stores its own location details and overrides `StartMeeting()` to display type-specific output. |
| Inheritance – Note → PublicNote, PrivateNote | `Note.cs`, `PublicNote.cs`, `PrivateNote.cs` | Note: 3–33, PublicNote: 3–14, PrivateNote: 3–26 | Abstract `Note` defines shared fields and behavior; subclasses implement `IsVisible()` differently based on whether access is open or restricted to a list of allowed users. |
| Interface – ICalendar | `ICalendar.cs`, `CalendarService.cs` | ICalendar: all, CalendarService: 7 | `ICalendar` defines the contract for meeting scheduling. `CalendarService` implements it, providing a concrete list-backed calendar for the group. |
| Interface – IMeetingNotes | `IMeetingNotes.cs`, `NoteService.cs` | IMeetingNotes: all, NoteService: 6 | `IMeetingNotes` defines the contract for note management. `NoteService` implements it, allowing notes to be created, edited, and retrieved. |
| Interface – IFileStorage | `IFileStorage.cs`, `MeetingResourceService.cs` | IFileStorage: all, MeetingResourceService: 5 | `IFileStorage` defines the contract for file operations. `MeetingResourceService` implements it using a `Dictionary` to store file name–content pairs. |
| Polymorphism – StartMeeting() override | `Meeting.cs`, `OnlineMeeting.cs`, `InPersonMeeting.cs`, `HybridMeeting.cs`, `CallMeeting.cs` | Meeting: 14–17, each subclass `StartMeeting()` | `StartMeeting()` is declared `virtual` in `Meeting` and overridden in all four subtypes. Each subtype prints type-specific details (link, location, conference number). |
| Polymorphism – IsVisible() override | `Note.cs`, `PublicNote.cs`, `PrivateNote.cs` | Note: 32, PublicNote: 9–12, PrivateNote: 22–25 | `IsVisible()` is declared `abstract` in `Note` and overridden in both subclasses. `PublicNote` always returns `true`; `PrivateNote` checks an allowed-users list. |
| Access Modifiers | All domain files | Various | `private` fields protect internal state (e.g., `_files`, `_meetings`, `_notes`). `public` properties expose read-only data via getters. `protected` is used on `Details` and `Content` so subclasses can read them without exposing them publicly. `private set` on properties like `UserID` and `Name` prevents external mutation. |
| Struct | `MeetingDetails.cs` | 3–15 | `MeetingDetails` is a struct because it is a small, value-type bundle of meeting metadata (title, date, type) with no behavior. It is passed by value into `Meeting` constructors, which is appropriate for lightweight data containers. |
| Enum – MeetingType | `MeetingType.cs` | 3–9 | `MeetingType` enumerates the four supported meeting formats. Used in `MeetingDetails` and `MeetingFactory` to drive meeting construction logic cleanly without string comparisons. |
| Enum – Role | `Role.cs` | 3–9 | `Role` enumerates the four user roles. Stored on every `User` and used to distinguish permissions and display role labels without magic strings. |
| Data Structure – Dictionary | `MeetingResourceService.cs` | 7 | `Dictionary<string, string>` maps file names to file content, enabling O(1) lookup, insertion, and deletion by file name. |
| Data Structure – List | `Group.cs`, `CalendarService.cs`, `NoteService.cs` | Group: 8–10, CalendarService: 9, NoteService: 8 | `List<T>` is used throughout to store ordered, dynamic collections of members, meetings, and notes. |
| I/O – Console UI | `ConsoleUI.cs` | All | `ConsoleUI` uses `Console.ReadLine()` for all user input and `Console.WriteLine()` for all output. The menu loop in `ShowMenu()` reads integer choices via `ReadChoice()` and dispatches to the appropriate feature handler. |

---

## 4. Design Patterns

| Pattern Name | Category | File Name | Line Numbers | Rationale |
|---|---|---|---|---|
| Factory Method | Creational | `MeetingFactory.cs` | 5–32 | The system needs to create four different `Meeting` subtypes based on user input, but the rest of the codebase should not need to know the construction details of each type. `MeetingFactory.CreateMeeting()` centralizes this logic, accepting a `MeetingType` enum value and returning the appropriate concrete meeting object. This keeps `CalendarService` and `ConsoleUI` decoupled from meeting construction. |

---

## 5. Design Decisions

**Layered namespace structure:** The project is split into `GroupMe.domain` (core classes), `GroupMe.contracts` (interfaces), `GroupMe.services` (implementations), and `GroupMe.factories` (object creation). This separation keeps concerns isolated, the domain does not depend on services, and services depend only on contracts, not on each other.

**Abstract base classes for Note and Meeting:** Both `Note` and `Meeting` are abstract because a plain instance of either would be meaningless a note is always public or private, and a meeting always has a specific format. Making them abstract enforces correct usage and enables polymorphism through `IsVisible()` and `StartMeeting()`.

**MeetingDetails as a struct:** Rather than adding title, date, and type directly as fields on `Meeting`, we grouped them into a `MeetingDetails` struct. This keeps the `Meeting` constructor clean, satisfies the struct rubric requirement, and models the idea that meeting metadata is a cohesive value-type unit.

**Role enum on User:** Rather than using string role labels or separate login logic, every `User` carries a `Role` enum value set at construction time. This makes role checks simple, type-safe, and free of magic strings throughout the codebase.

**ConsoleUI as the single interaction point:** All console I/O is contained within `ConsoleUI`. Domain classes and services never call `Console.ReadLine()`  they only `Console.WriteLine()` for status messages. This makes the UI layer easy to locate and replace if a GUI were ever added.

---

