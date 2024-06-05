# OneImlx Drivers SDK Conceptual Design

## Overview

The OneImlx Drivers SDK provides a structured approach to creating and managing drivers. The SDK includes interfaces for basic driver operations, actions, lifecycle management, event handling, and configuration.

## Interfaces Overview

### IDriver
Represents the basic abstraction for a driver, providing necessary resource management.

### IDriverAction
Encapsulates the main action performed by the driver, allowing for different types of actions.

### IDriverLifecycle
Manages the life-cycle of the driver, including initialization, connection, disconnection, and rendering.

### IDriverEvents
Handles events that occur during the driver's life-cycle, providing hooks for custom behavior.

### IDriverConfiguration
Enables the driver to configure itself with specific settings.

## Conceptual Sequence Diagram

```mermaid
sequenceDiagram
    participant Driver as IDriver
    participant Lifecycle as IDriverLifecycle
    participant Action as IDriverAction
    participant Events as IDriverEvents
    participant Configuration as IDriverConfiguration

    Driver->>Lifecycle: InitializeAsync()
    Lifecycle-->>Driver: Initialization Complete
    Lifecycle->>Events: OnInitializedAsync()

    Driver->>Configuration: ConfigureAsync()
    Configuration-->>Driver: Configuration Applied

    Driver->>Lifecycle: ConnectAsync()
    Lifecycle-->>Driver: Connection Established
    Lifecycle->>Events: OnConnectedAsync()

    Driver->>Action: ExecuteAsync()
    Action-->>Driver: Action Result

    Driver->>Lifecycle: RenderAsync()
    Lifecycle-->>Driver: Rendering Complete
    Lifecycle->>Events: OnRenderedAsync()

    Driver->>Lifecycle: DisconnectAsync()
    Lifecycle-->>Driver: Disconnection Complete
    Lifecycle->>Events: OnDisconnectedAsync()

    Driver->>Driver: Dispose()
    Driver-->>Driver: Driver Disposed
