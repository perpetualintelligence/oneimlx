# OneImlx.Licensing

## Introduction

`OneImlx` is a unified claims-based framework for managing both identity-related authorizations and licensing entitlements. At its core, it addresses two pivotal questions: **what** actions or operations can a user or entity perform (i.e., "can-do") and **what** are they licensed for (i.e., "has-license-for").

## Guiding Principles

### 1. Authorization
- **`who` -> `can-do` -> `what`**: After identifying a user or entity, `OneImlx` determines the specific actions or operations they are authorized to perform.

### 2. Licensing
- **`who` -> `has-license-for` -> `what`**: This principle checks and confirms the licenses associated with a user or entity, ensuring they access or use only what they are licensed for.

By harmoniously converging IAM with Licensing, `OneImlx` provides a comprehensive framework that ensures both security and compliance, without unnecessary complexity.

## Terminology
- **who**: Refers to the user or entity being evaluated. In a claims-based context, it represents the claim subject.
- **can-do**: Indicates the permissible actions or operations that the identified user or entity is authorized to perform, derived from their assigned claims.
- **has-license-for**: Addresses the entitlements or licenses associated with a user or entity.
- **what**: Represents the end resource, service, or product that the "who" wishes to access or interact with.

## Cross-Platform 
`OneImlx` is designed to be inherently cross-platform, ensuring functionality across Windows, Linux, macOS, and other platforms. This flexibility guarantees wide applicability, regardless of platform preference.

## Deployment Agnostic
Whether deployed on-premises, in a hybrid setting, or cloud-native, `OneImlx`'s deployment-agnostic nature assures consistent functionality, scalability, and adaptability across various infrastructure models.

## What It Is Not
While `OneImlx` offers a layer for access, permission management, and licensing, it is not designed for authentication. For that foundational block in the security landscape, well-established solutions exist:
- **Duende IdentityServer**: A commercial OpenID Connect and OAuth 2.0 framework for ASP.NET Core, succeeding IdentityServer.
- **MSAL (Microsoft Authentication Library)**: Consistent authentication for any Microsoft identity.
- **Google Auth**: A robust identity solution facilitating quick user authentication to apps.
- **AWS Cognito**: Amazon's authentication solution controlling user access to AWS resources.
- **Azure RBAC**: Microsoft Azure's Role-Based Access Control system for fine-grained access management of Azure resources.

## Feedback
Your feedback helps shape `OneImlx`. For suggestions, issues, or queries, please visit our [GitHub Repository Issues section](https://github.com/PerpetualIntelligence/OneImlx/issues).

## Licensing and Pricing
Details on `OneImlx` licensing and pricing will be determined closer to the pre-release, aiming for competitive pricing balanced with feature richness.
