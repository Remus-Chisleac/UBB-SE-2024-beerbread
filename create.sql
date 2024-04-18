use ISS_beerbread

CREATE TABLE accounts(
	id int primary key not null IDENTITY,
	guid varchar(65) not null,
	email varchar(100) not null,
	username varchar(100) not null,
	salt varchar(65) not null,
	hashedPassword varchar(256) not null,
)

CREATE TABLE songs(
	id int primary key not null IDENTITY,
	songName varchar(100) not null,
	artistName varchar(100) not null,
	likes int not null,
	urlSong varchar(100) not null,
	urlImage varchar(100) not null,
)


CREATE TABLE playlists(
	id int primary key not null IDENTITY,
	name varchar(100) not null,
	isPrivate bit not null,
	owner int foreign key references accounts(id)
)


CREATE TABLE songs_in_playlist(
	idPlaylist int foreign key references playlists(id),
	idSong int foreign key references songs(id)
	primary key (idPlaylist, IdSong)
)


CREATE TABLE users(
	id int primary key references accounts(id),
	historyPlaylist int foreign key references playlists(id),
	likedPlaylist int foreign key references playlists(id),
	blockedplaylist int foreign key references playlists(id),
)
CREATE TABLE artists(
	id int primary key references users(id),
	name varchar(100) not null,
)

CREATE TABLE album(
	id int primary key not null IDENTITY,
	idArtist int foreign key references artists(id),
	playlist int foreign key references playlists(id),
)

CREATE TABLE test(
	id UNIQUEIDENTIFIER primary key
)
insert into accounts values ('test1','test','test','test')

select *
from accounts 

select *
from users

select *
from playlists

select * 
from songs

delete from songs where id = 4
delete from playlists
delete from users
delete from accounts

SELECT email, username, salt, hashedPassword FROM accounts WHERE email ='t@gmail.com'


id int primary key not null IDENTITY,
	songName varchar(100) not null,
	artistName varchar(100) not null,
	likes int not null,
	urlSong varchar(100) not null,
	urlImage varchar(100) not null,
	/CaravanPalace-Raccoons.mp3

INSERT INTO songs(songName,artistName,likes,urlSong,urlImage) Values
	('Human Leather Shoes for Crocodile Dandies','CaravanPalace',0,'/Caravan Palace - Human Leather Shoes for Crocodile Dandies.mp3','/Caravan Palace - Human Leather Shoes for Crocodile Dandies.png')



