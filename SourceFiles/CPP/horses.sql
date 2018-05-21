



/*
NAME:		TOM EISENBRANDT
ZID:		Z1771209
CLASS:		CSCI 466
SECTION:	2
PROJECT:	10,11,12
DUE DATE:	NOVEMBER 27 2017 11:59 PM

SQL horse tables
*/

/*
horse(horse_id, name, sire, dam)
race(race_id,name,distance)   //m is miles, f is furlongs
runsin(hid,rid,dt,tm,finish)  //hid is fk into horse, rid is fk into race
*/

drop table if exists runsin;
drop table if exists horse;
drop table if exists race;

/*
HORSE
*/

create table horse
	(horse_id int primary key auto_increment,
	name varchar(25),
	sire varchar(25),
	dam varchar(25));
	
insert into horse (name,sire,dam)
	values ('Secretariat','Bold Ruler','Somethingroyal'), 	
			("Man O' War",'Fair Play','Mahubah'),
			('Spectacular Bid','Bold Bidder','Spectacular'),
			('Citation','Bull Lea','Hydroplane'),
			('Native Dancer','Polynesian','Geisha'),
			('Seattle Slew','Bold Reasoning','My Charmer'),
			('Affirmed','Exclusive Native',"Won't tell You");

/*
RACE
*/
			
			
			
			create table race
	(race_id int primary key auto_increment,
	name varchar(30),
	distance  varchar(10));
	
insert into race (name, distance)
	values ('Allow','7 f'),							
			('Allow','6 f'),						
			('Allow','6 1/2 f'),					
			('Allow','1 m'),						
			('Allow','1 1/16 m'),					
			('American Derby','1 1/8 m'),
			('American Derby','1 1/4 m'),
			('American Handicap','1 1/8 m'),
			('Argonaut Handicap','1 1/16 m'),
			('Arlington Classic Stakes','1 mile'),
			('Arlington Invitational','1 1/8 m'),
			('Bay Shore','7 f'),
			('Belmont Futurity Trial','6 f'),
			('Belmont Stakes','1 3/8 m '),
			('Belmont Stakes','1 1/2m'),
			('Belmont Stakes','6 f'),
			('Belmont Stakes','1 1/2m'),
			('Blue Grass Stakes','1 1/8 m'),
			('Californian Stakes','1 1/8 m'),
			('Californian Stakes','1 1/16 m'),
			('Canadian International','1 5/8 m'),
			('Champagne','1 m'),
			('Chesapeake','1 1/16 m'),
			('Chesapeake Trial','6 f'),
			('Dwyer','1 1/8 m'),
			('Dwyer','1 1/4 m'),
			('East View','1 1/16 m'),
			('Elementary Stakes','5 f'),
			('Everglades Stakes','1 1/8 m'),
			('Flamingo Stakes','1 1/8 m'),
			('Flash Stakes','5 1/2 f'),
			('Florida Derby','1 1/8 m'),
			('Forty-Niners Handicap','1 1/8 m'),
			('Fountain of Youth','1 1/16 m'),
			('Futurity Stakes','6 f'),
			('Futurity Stakes','6 1/2 f'),
			('Garden State Futurity','1 1/16 m'),
			('Gold Cup','1 5/8 m'),
			('Golden Gate Handicap','1 1/4 m'),
			('Golden Gate Mile','1 m'),
			('Gotham','1 1/16 m'),
			('Gotham','1 m'),
			('Grand Union Hotel Stakes','6 f'),
			('Haskell Invitational','1 1/8 m'),
			('Hollywood Derby','1 1/8 m'),
			('Hollywood Gold Cup','1 1/4 m'),
			('Hollywood Premiere Hcp.','6 f'),
			('Hopeful','6 f'),
			('Hopeful','6 1/2 f'),
			('Hudson Hdcp.','5 f'),
			('Jersey','1 1/4 m'),
			('Jim Dandy','1 1/8 m'),
			('Jockey Club Gold Cup','2 miles'),
			('Jockey Club Gold Cup','1 1/2m'),
			('Keene Memorial','5 1/2 f'),
			('Kenilworth Park Gold Cup','1 1/4 m'),
			('Kentucky Derby','1 1/4 m'),
			('Laurel Futurity Stakes','1 1/16 m'),
			('Lawrence Realization','1 5/8 m'),
			('Malibu Stakes','7 f'),
			("Man O' War Stakes",'1 1/2m'),
			('Marlboro Cup Invitational Hcp','1 1/8 m'),
			('Meadowlands Cup','1 1/4 m'),
			('Mervyn Leroy','1 1/16 m'),
			('Metropolitan Handicap','1 m'),
			('Miller Stakes','1 3/16 m'),
			('MSW','6 f'),
			('Pat Day Mile','1 m'),
			('Paterson Handicap','1 1/8 m'),
			('Pimlico Futurity','1 1/16 m'),
			('Pimlico Special Stakes','1 3/16 m'),
			('Potomac','1 1/16 m'),
			('Preakness Stakes','1 3/16 m'),
			('Preakness Stakes','1 1/8 m'),
			('San Antonio Handicap','1 1/8 m'),
			('San Felipe Stakes','1 1/16 m'),
			('San Fernando Stakes','1 1/8 m'),
			('San Juan Capistrano Stakes','1 3/4 m'),
			('Sanford','6 f'),
			('Santa Anita Derby','1 1/8 m'),
			('Santa Anita Handicap','1 1/4 m'),
			('Saratoga Special','6 f'),
			('Seminole','7 f'),
			('Stars and Stripes','1 1/8 m'),
			('Strub Stakes','1 1/4 m'),
			('Stuyvesant','1 m'),
			('Stuyvesant','1 1/8 m'),
			('Swaps','1 1/4 m'),
			('Sysonby Mile','1 m'),
			('Tanforan Handicap','1 1/4 m'),
			('Travers Stakes','1 1/4 m'),
			('Tremont','6 f'),
			('United States Hotel Stakes','6 f'),
			('Washington Futurity','6 f'),
			('Washington Park Handicap','1 1/8 m'),
			('Whitney Handicap','1 1/8 m'),
			('Withers','1 m'),
			('Wood Memorial','1 1/8 m'),
			('Woodward Stakes','1 1/4 m'),
			('Woodward Stakes','1 1/2m'),
			('Youthful Stakes','5 1/2 f');



/*
RUNSIN
*/

create table runsin
	(hid int,
	rid int,
	dt char(10),
	tm char(7),
	finish int,
	primary key (hid,rid),
	foreign key(hid) references horse(horse_id),
	foreign key(rid) references race(race_id));
	
insert into runsin (hid,rid,dt,tm,finish)
	values (1,21,"10/28/1973",'2:41.80',1),
		(1,61,"10/08/1973",'2:24.80',1),
		(1,100,"09/29/1973",'2:25.80',2),
		(1,15,"06/09/1973",'2:24.00',1),
		(1,73,"05/19/1973",'1:53.00',1),
		(1,57,"05/05/1973",'1:59.40',1),
		(2,56,"10/12/1920",'2:03.00',1),
		(2,72,"09/18/1920",'1:44.80',1),
		(2,14,"06/12/1920",'2:14.20',1),
		(2,74,"05/18/1920",'1:51.60',1),
		(2,50,"06/23/1919",'1:01.60',1),
		(3,19,"06/08/1980",'1:45.80',1),
		(3,15,"06/09/1979",'2:28.60',3),
		(3,57,"05/09/1979",'2:02.40',1),
		(3,73,"05/19/1979",'1:54.20',1),
		(3,5,"08/26/1979",'1:41.60',1),
		(4,2,"04/26/1951",'1:09.80',3),
		(4,39,"06/24/1950",'1:34.00',2),
		(4,71,"10/29/1948",'1:59.80',1),
		(4,16,"06/12/1948",'2:28.20',1),
		(4,57,"05/01/1948",'2:05.40',1),
		(4,73,"05/15/1948",'2:02.40',1),
		(5,1,"08/16/1954",'1:35.20',1),
		(5,57,"05/02/1953",'2:02.00',2),
		(5,15,"06/13/1953",'2:28.00',1),
		(5,73,"05/23/1953",'1:57.80',1),
		(5,31,"08/04/1952",'1:06.00',1),
		(6,57,"05/07/1977",'2:02.20',1),
		(6,22,"10/16/1976",'1:34.40',1),
		(6,73,"05/21/1977",'1:54.40',1),
		(6,88,"07/03/1977",'1:58.6',4),
		(6,15,"06/11/1977",'2:29.60',1),
		(6,69,"09/05/1978",'1:48.00',2),
		(7,54,",10/14/1978",'2:27.20',5),
		(7,4,"08/29/1979",'1:34.00',1),
		(7,60,"01/07/1979",'1:21.00',3),
		(7,15,"06/10/1978",'2:26.80',1),
		(7,73,"05/20/1978",'1:54.40',1),
		(7,57,"05/06/1978",'2:01.20',1);
		
/*

*/		
		
		
		
