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
