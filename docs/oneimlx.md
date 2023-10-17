# OneImlx

## Introduction
`OneImlx` is a unified claims-based framework that seamlessly integrates Identity and Access Management (IAM) with Licensing. At its core, it operates based on two main guiding principles: understanding **what** actions or operations a user or entity can perform (i.e., "can-do") and determining **what** they are licensed for (i.e., "has-license-for").

## Guiding Principles

### 1. Authorization
- **`who` -> `can-do` -> `what`**: This principle ensures that after identifying a user or entity, `OneImlx` accurately determines the specific actions or operations they are authorized to perform.

### 2. Licensing
- **`who` -> `has-license-for` -> `what`**: Here, This principle checks and confirms the licenses associated with a user or entity, making sure they access or use only what they are licensed for.

## Terminology

- **who**: Refers to the user or entity in context. It's essentially the subject of the claims, which can be an individual, system, or another entity within the ecosystem. In `OneImlx`, this is typically represented by a unique identity claim.

- **can-do**: Represents the actions, operations, or permissions that a user or entity is authorized to perform. In a claims-based system, these are presented as specific claims detailing the permissible actions for the given 'who'.

- **has-license-for**: An assertion about a user or entity's rights or entitlements. Unlike the 'can-do' which is about permissions, 'has-license-for' delves into the licenses held by the user or entity. In `OneImlx`, licenses are also represented as specific claims, detailing the resources or services the 'who' is licensed to access or utilize.

- **what**: Refers to the target or object of the action or the license. In the context of `OneImlx`, it could be a system resource, a feature, a dataset, or any other entity that a user interacts with or utilizes. The exact nature of 'what' is determined by the specifics of the claim in question.

By harmoniously converging IAM with Licensing, `OneImlx` provides a comprehensive framework that ensures both security and compliance, without unnecessary complexity.
