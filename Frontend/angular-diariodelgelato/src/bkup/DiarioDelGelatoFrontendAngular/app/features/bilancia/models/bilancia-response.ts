export interface BilanciaResponse {
    success: boolean;
    connected: boolean;
    responseCode: number;
    errorCode: number;
    message: string; 
    readingInGrams: boolean;
    weight: number;
}
