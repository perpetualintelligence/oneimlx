# OneImlx Licensing Framework Specification

## Prerequisite
Before diving into the licensing specification, it's essential to understand our IAM (Identity and Access Management) framework. Please refer to the [OneImlx IAM Specification](iam.md).

## Introduction
`OneImlx` licensing extends our IAM concepts to form a claim-based licensing authorization framework. It's designed to offer a modern, cross-platform, deployment agnostic licensing solution.

## Overview
Central to our framework is the principle: **`who` -> `has-license-for` -> `what`**.

### Components
- **Who**: The authenticated entity desiring a license.
- **Has-License-For**: The set of licensing claims granted to the entity.
- **What**: The specific resource (software *or* product feature) for which the license is issued.

## IAM in Licensing

Traditionally, licensing systems and identity & access management (IAM) systems have operated in separate realms. The former ensures that users possess the right to use a particular software or service, while the latter ensures that users have the appropriate permissions to perform actions within that software or service.

`OneImlx`, proposes a seamless integration between licensing and IAM, combining the verification of both a identiy's right to access and their permissions into a unified system. This integrated model offers streamlined management, better user experience, and enhanced security.

1. **Authentication**: 
    At the heart of every IAM system is the principle of authentication. In our design, this is tied directly to licensing. A user (or more specifically, a `LicenseIdentity`) is authenticated if they hold a valid license. This transforms the license from a mere "right to use" into a core component of identity verification.

2. **Authorization**: 
    After authentication, we address the question: "What can an authenticated identity do?" This is where the integration shines. With the `HasPermission` method, we determine the actions (or permissions) a licensed user can execute on their licensed resources. 

3. **Role-Based Access Control (RBAC)**: 
    Typically, IAM solutions leverage RBAC to group permissions under roles for easier management. In our design, a role is analogous to a license. By associating roles (or licenses) with sets of permissions, we create a clear structure where each license not only grants access to a resource but also defines the permissible actions on that resource.

4. **Unified Management**: 
    By integrating licensing with IAM, organizations have a single point of management for both access and permissions, streamlining administrative workflows.
  
5. **Enhanced Security**: 
    This integrated approach ensures that every action, from access to execution, is governed by a valid license, enhancing security and reducing potential vulnerabilities.
  
6. **Scalability and Flexibility**: 
    The model is designed to scale with growing organizations and adapt to complex licensing relationships. Whether granting broad permissions across multiple resources or fine-tuning permissions for specific roles, this system is both robust and adaptable.

7. **Improved User Experience**: 
    For end-users, the integration means fewer steps to gain access and perform actions, leading to a smoother, more intuitive experience.

By fusing the worlds of licensing and IAM, we've crafted a system that’s not just about access, but about actions. This forward-thinking design ensures that licensing becomes a dynamic part of the user experience, ensuring both access and the right to act.


## Terminology
For clear comprehension, here are the primary terms:

- **LicenseIdentity**: Represents licensing specifics of an entity.
- **LicensePrincipal**: Seeks licensing claims.
- **License**: Collection of licensing claims.
- **Resource**: Target for permissions and licenses.

## Core Interactions
1. **LicenseIdentity & LicensePrincipal**: Interaction between licensed entity and its authorizing counterpart.
2. **LicensePrincipal & License**: Licensing claims granted to the principal.
3. **License & Resource**: Specifies the licensed actions or features for a given resource.
4. **License Distribution**: Involves generating, validating, and distributing a license artifact.

## Detailed Specifications
- **ILicenseIdentity Interface**: Represents an entity with licensing attributes. It may contain attributes such as `expiry`, `featuresEnabled`, etc.
- **ILicensePrincipal Interface**: Represents an entity that can seek licensing claims based on the attributes of LicenseIdentity.
- **ILicense Interface**: Contains methods to define, modify, and query licensing claims associated with resources.
- **ILicensedResource Interface**: Represents resources that can be licensed. It contains attributes and methods related to licensing specifics of a resource.
- **ILicenseGenerator Interface**: Provides methods for generating license files or keys based on specific claims.
- **ILicenseValidator Interface**: Holds methods for validating given licenses against specific claims or resources.
- **ILicenseDistributor Interface**: Contains methods to distribute licenses, possibly through email, file download, etc.
- **IResource Interface**: (from IAM) Represents software or product feature, with methods to define, modify, and retrieve resources.
