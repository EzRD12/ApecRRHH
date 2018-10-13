/**
 * Represents a basic operation response
 */
export class BasicOperationResult<T> {
    message: string;
    success: boolean;
    operationResult: T;
}
