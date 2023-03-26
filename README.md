# README

> # DEPRECATED
> This version is deprecated for a new version. This version will only exist as long as a form of documentation.

## Introduction 

The original nttb-tournament project had a few limitations which will be addressed in V2.

- The ability to use on multiple devices
- The ability to create tournaments with multiple divisions
- The ability to create tournaments with multiple rounds
- The ability to have a double tournament

## Infrastructure

- API: Written in nodejs (NestJs)
- Frontend: Written in Angular
- Database: MongoDB
- Proxy: ???

## Running the application

To run the application the easiest method is using docker-compose

## Some goals

1. We want to have realtime updates of the tournament, so that the user can see the changes as they happen. For that we will use websockets.
2. We want to have a nice UI, so that the user can easily navigate through the application. For that we will use material design.
3. We want to have everything as secure as possible so that the user can be sure that their data is safe. For that we will use JWT tokens.
