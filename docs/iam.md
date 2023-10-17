# OneImlx IAM Framework Specification

## Introduction
`OneImlx` is a comprehensive IAM (Identity and Access Management) framework, meticulously crafted to be inherently cross-platform and deployment agnostic.

- **Cross-Platform Capability**: `OneImlx` operates effectively across a spectrum of environments and platforms, including Windows, Linux, macOS, and other operating systems, ensuring a unified set of functionalities and consistent behavior.
- **Deployment Agnostic Design**: The architecture of `OneImlx` supports various deployment scenarios — from cloud-centric models, on-premises configurations, hybrid systems, to edge computing environments. Its modular foundation facilitates the flexible integration of components based on each deployment's specific demands.

## Overview
Central to our framework is the principle: **`who` -> `can-do` -> `what`**.

### Components
- **Who**: The authenticated entity seeking access to a resource.
- **Can-Do**: The set of permissions or actions granted to the identity.
- **What**: The resource that the identity intends to access.

## Terminology
For clarity, here are the key terms used throughout this specification:

- **Identity**
  - **Definition**: The authenticated entity.
  - **Responsibility**: Manages authentication status and metadata.
- **Principal**
  - **Definition**: The authorization entity.
  - **Responsibility**: Manages and requests access rights based on Identity's authorization.
- **Permission**
  - **Definition**: Actionable rights.
  - **Responsibility**: Define actionable rights without knowing the assignees.
- **Role**
  - **Definition**: Aggregate of permissions.
  - **Responsibility**: Recognizes aggregated permissions but remains agnostic of individual assignees.
- **Resource**
  - **Definition**: Target for permissions.
  - **Responsibility**: Maintains metadata and remains indifferent to access mechanisms.
- **IdentityGroup**
  - **Definition**: Aggregate of identities.
  - **Responsibility**: Knows member identities and potential roles.
- **ResourceGroup**
  - **Definition**: Aggregate of resources.
  - **Responsibility**: Recognizes contained resources and potentially influences scopes.
- **Scope**
  - **Definition**: Boundary where permissions/roles apply.
  - **Responsibility**: Recognizes encompassed resources/resource groups but doesn't manage permissions.
- **Policy**
  - **Definition**: High-level access rules.
  - **Responsibility**: Dictates access conditions.

## Why We Don't Provide Authentication?
`OneImlx` focuses strictly on the access management and authorization aspect of IAM. By separating authentication, we ensure:

1. **Flexibility**: Users can integrate `OneImlx` with any existing or future authentication solutions without constraints.
2. **Specialization**: By focusing solely on authorization, we allow for refined features and performance optimizations.
3. **Security**: We avoid potential vulnerabilities associated with a one-size-fits-all approach to authentication.

## Core Interactions
1. **Identity & Principal**: The relationship between the authenticated entity and its authorizing counterpart.
2. **Identity & IdentityGroup**: Identities can belong to multiple groups influencing their roles.
3. **Resource & ResourceGroup**: Resources may be part of multiple groups affecting their scopes.
4. **Principal & Role**: Principals acquire roles through identity's group membership or direct assignment.
5. **Role & Permission**: Roles are collections of permissions.
6. **Permission & Resource**: Permissions define actions on resources.
7. **Role, Permission, & Scope**: Roles collect permissions; scopes define their applicability.
8. **Policy**: Can determine the validity of roles or permissions for specific resources.

## Detailed Specifications
- **IPrincipal Interface**: Represents an entity that can request access based on the authentication of an identity.
- **IIdentity Interface**: Represents an entity with authentication capabilities, holding methods related to identity management.
- **IPermission Interface**: Holds methods to define, modify, and query permissions associated with resources.
- **IResource Interface**: Symbolizes assets with methods to define, modify, and retrieve resources.
- **IRole Interface**: Outlines the structure for roles, featuring methods for role management and permission association.
- **IScope Interface**: Provides methods to determine and query the scope of permissions and roles.
- **IGroup Interface**: Manages identity collections.
- **IPolicy Interface**: Holds methods for policy management, influencing resources, roles, and permissions.
- **IStore Interface**: An abstraction for storage solutions, offering CRUD methods for data related to IAM components.
- **IAccessManager Interface**: The core layer providing methods to assess access requests.
- **IAuthenticationProvider Interface**: Abstracts the authentication process, allowing for integration with various Identity Providers.

## Identity Interfaces in OneImlx
The OneImlx identity framework provides a set of interfaces that define various types of entities within the system. These interfaces serve as blueprints for representing and interacting with different types of entities, ensuring consistency and extensibility.

- **IPersonIdentity**: Represents individuals or users within the OneImlx ecosystem. It includes user-specific attributes such as email.
- **IServiceIdentity**: Represents service entities and their associated properties.
- **IProductIdentity**: Represents product entities with their unique characteristics.
- **IDeviceIdentity**: Represents device or hardware entities, accommodating device-specific attributes.
- **IEquipmentIdentity**: Represents large equipment or machinery entities within the system.
- **IDomainIdentity**: Represents domains or engineering disciplines, allowing for specialization.
- **IProcessIdentity**: Represents manufacturing or operations processes, allowing for process-specific attributes.
- **IOperationIdentity**: Represents specialized operations within the OneImlx framework, with a focus on operation type.
- **IDepartmentIdentity**: Represents departments or organizational units within entities.
- **IFacilityIdentity**: Represents facilities or physical locations within the OneImlx ecosystem.
- **IFactoryIdentity**: Represents factory entities and includes properties such as factory location.
- **IOrganizationIdentity**: Represents organizations, businesses, governments, or legal entities, serving as the overall owner.

These identity interfaces ensure a consistent approach to identity across the OneImlx framework, making it easier to work with a wide range of entities while maintaining clarity and structure.

## Modular Design
The strength of `OneImlx` lies in its modular design. Each component has a clear responsibility and interfaces harmoniously with others. This modularity ensures scalability, maintainability, and efficiency.

## Deployment Agnostic and On-Premises Consideration
`OneImlx` is **deployment agnostic**. This ensures that `OneImlx` can integrate with various environments, whether it's cloud services like AWS, Azure, GCP, hybrid environments, or entirely on-premises systems.

## Examples
[Provide practical examples here.]

## Dependencies
[Detail any external dependencies or prerequisites here.]

## Implementation Guidance
[Provide high-level guidance on how to implement or integrate with `OneImlx` here.]

## Versioning
This is Version 1.0 of the `OneImlx` IAM Specification.

## Feedback
For feedback or questions regarding this specification, please visit our official GitHub repo and raise an issue: [OneImlx Feedback](https://github.com/perpetualintelligence/oneimlx/issues).

## Acknowledgments
[List any contributors or sources that were instrumental in shaping this specification here.]

## Licensing and Pricing
The `OneImlx` framework is currently under development. A comprehensive pricing plan will be released towards the end of the preview release of the `OneImlx` framework. 
