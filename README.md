## Brief introduction

This project is to show one of many approaches how modular monolith could look like. Note that not all parts are finished. You should treat it as a demo or a kind of prototype.

Main goals are to separate bouded contexts as modules (simultaneously ensure integration between them), separate framework dependent application pieces such as apis, infrastructure etc. and make them interchangeable.

## Overall technical guidelines

Divide into modules and provide a mediator to integrate them.
Each single module can have a different architecture which depends on needs. Either CRUD or full layered DDD approaches are welcome.
Each single module can be moved into a microservice.
Use variety building blocks.
Prepared for dockered debugging in vscode.

## HRP - Human Resources and Payroll

There are two separate modules.

The "HumanResources" module which is responsible for building and managing employee base. For the purposes of demonstrating diversity of modules, this one have been made as simple CRUD.

The unit tests is ommitted for CRUD module. Basically, there is no important business logic to be tested.

All efforts are focused on Payroll module. The module is built in layered manner. Domain and Application layer can be easily tested (the examples are shown in tests folder)

Shared project basically contains some commons and tools to manage events, commands etc (simple implementation of event bus and tools needed for module registration)

Integration among modules is done through events. There is no integration events, just simple domain events. None of modules knows about other ones (even projects have no relations between)
Integrator module plays the role of mediator. With this approach we have only one-directional relation outgoing from Integrator module. It listens for events published by one module and performs appropiate action in other modules.

Host project is typically bootstrapper.