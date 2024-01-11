
create table pomodoro(
sess_id int NOT NULL,
sess_name varchar (255),
sess_time int NOT NULL,
short_break int NOT NULL,
long_break int NOT NULL,
frequency int NOT NULL,
timeslot datetime NOT NULL,

primary key (sess_id)

);

create table todo(
todo_id int NOT NULL,
todo_name nvarchar,
sub_todo int,
checked int,
timeslot datetime NOT NULL,
primary key (todo_id)

);

CREATE TABLE reminder(
    rem_id INT IDENTITY(1,1) PRIMARY KEY,
    rem_name NVARCHAR(MAX),
    set_date DATETIME NOT NULL,
    timeslot DATETIME NOT NULL
);

create table notes
(
st_id int NOT NULL,
st_name nvarchar,
timeslot datetime NOT NULL,
primary key (st_id)

);

create table calender (
event_id int NOT NULL,
event_name varchar(255),
event_type varchar (255) NOT NULL,
timeslot DATE NOT NULL,
primary key (event_id)
);

create table habits(
habit_id int NOT NULL,
userID int,
habit_name varchar(255),
HabitStatus VARCHAR(10) not null,
perday int,
streakCount int,
completeDate datetime,
primary key (habit_id,userID) 
);

create table emotion(
emo_id int NOT NULL,
emo varchar(255),
timeslot datetime NOT NULL,
primary key (emo_id)
);


select todo_name 
from todo
where checked >0

select sub_todo
from todo 
where todo_id =1

select rem_name
from reminder 
where set_date = 12/18/2023

select count(*)
from callender
where event_type = 'bday'

select habit_name
from habits
where c_num > Frequency or c_num = frequency
