# OneImlx IAM Specification

## Introduction:
`OneImlx` is a comprehensive IAM (Identity and Access Management) framework, meticulously crafted to be inherently cross-platform and deployment agnostic.

- **Cross-Platform Capability**: `OneImlx` operates effectively across a spectrum of environments and platforms, whether it's Windows, Linux, macOS, or other operating systems. This ensures a unified set of functionalities and consistent behavior.
  
- **Deployment Agnostic Design**: The architecture of `OneImlx` supports a multitude of deployment scenarios — from cloud-centric models, on-premises configurations, hybrid systems, to edge computing environments. Its modular foundation facilitates the flexible integration of components, adapting to the specific demands of each deployment scenario.

The foundational philosophy behind `OneImlx` emphasizes flexibility in deployment combined with broad platform support, providing a dynamic toolset for all IAM requirements.

## Overview
At the heart of our framework is the principle: **`who` -> `can-do` -> `what`**.

### Components:
- **Who**: The authenticated entity seeking access to a resource.
- **Can-Do**: The set of permissions or actions granted to the identity.
- **What**: The resource that the identity intends to access.

## Terminology:
To facilitate understanding, here are key terms used throughout this specification:

- **Identity**: Unique entity for authentication.
- **Permission**: Actionable rights.
- **Role**: Aggregate of permissions.
- **Resource**: Target for permissions.
- **IdentityGroup**: Aggregate of identities.
- **ResourceGroup**: Aggregate of resources.
- **Scope**: Boundary for permissions/roles applicability.
- **Policy**: High-level access rules.

## Core Concepts

### Identity
- **Definition**: A unique entity capable of authentication.
- **Responsibility**: Manage its authentication status and metadata.

### Permission
- **Definition**: Specifies actions allowed on resources.
- **Responsibility**: Define actionable rights but remains unaware of assignees.

### Role
- **Definition**: An aggregate of permissions.
- **Responsibility**: Recognizes aggregated permissions but remains agnostic of individual assignees.

### Resource
- **Definition**: A target for permissions.
- **Responsibility**: Maintains its metadata but is indifferent to access mechanisms.

### IdentityGroup
- **Definition**: An aggregate of identities.
- **Responsibility**: Knows member identities and potentially associated roles.

### ResourceGroup
- **Definition**: An aggregate of resources.
- **Responsibility**: Recognizes contained resources and potentially influences scopes.

### Scope
- **Definition**: A boundary where certain permissions/roles apply.
- **Responsibility**: Recognizes encompassed resources/resource groups but doesn't manage permissions.

### Policy
- **Definition**: High-level access rules potentially superseding roles or permissions.
- **Responsibility**: Dictate access conditions.

## Why We Don't Provide Authentication?
`OneImlx` focuses strictly on the authorization aspect of IAM. The reasons include:

1. **Flexibility**: Integration with any existing or future authentication solutions without constraints.
2. **Specialization**: Focused solely on authorization for refined features and performance.
3. **Security**: Avoiding potential vulnerabilities from a one-size-fits-all approach.

## Core Interactions
1. **Identity & IdentityGroup**: Identities can belong to multiple groups influencing their roles.
2. **Resource & ResourceGroup**: Resources may be part of multiple groups affecting their scopes.
3. **Identity & Role**: Identities acquire roles through group membership or direct assignment.
4. **Role & Permission**: Roles are collections of permissions.
5. **Permission & Resource**: Permissions define actions on resources.
6. **Role, Permission, & Scope**: Roles collect permissions; scopes define their applicability.
7. **Policy**: Determines the validity of roles or permissions for specific resources.

## Detailed Specifications
Here are interfaces central to the framework's operation:

### IIdentity Interface
- Holds methods related to identity management.

### IPermission Interface
- Methods to define, modify, and query permissions.

### IResource Interface
- Functions to define, modify, and retrieve resources.

### IRole Interface
- Methods for role management and permission association.

### IScope Interface
- Methods to determine and query the scope of permissions and roles.

### IGroup Interface
- Manages identity collections.

### IPolicy Interface
- For policy management, potentially influencing resources, roles, and permissions.

### IStore Interface
- CRUD methods for IAM components data.

### IAccessManager Interface
- Provides methods to assess access requests.

### IAuthenticationProvider Interface
- Abstracts the authentication process.

## Modular Design
The strength of `OneImlx` lies in its modular design. Each component has a distinct role and interfaces seamlessly with others, ensuring scalability, maintainability, and efficiency.

## Deployment Considerations
`OneImlx` is **deployment agnostic**. This means it can:

- **Integrate with Cloud Services**: Seamlessly adapt to services like AWS, Azure, GCP, etc.
  
- **Work in Hybrid Environments**: Unify access management for both on-premises and cloud resources.
  
- **Operate Fully On-Premises**: Ideal for businesses with strict compliance requirements.

## Getting Started
For those looking to embark on their journey with `OneImlx`, refer to our [Installation Guide](#) and [Configuration Documentation](#) for step-by-step instructions and advanced features.

