export class ApiResponse {
  statusCode: number | null;
  success: boolean | null;
  message?: string | null;
  data?: any | null;

  constructor(
    statusCode: number | null,
    success: boolean | null,
    message: string | null = null,
    data: any = null
  ) {
    this.statusCode = statusCode;
    this.success = success;
    this.message = message;
    this.data = data;
  }
}
