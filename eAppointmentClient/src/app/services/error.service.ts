import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SwalService } from './swal.service';

@Injectable({
  providedIn: 'root'
})
export class ErrorService {

  constructor(
    private swal: SwalService
  ) { }

  errorHandler(err: HttpErrorResponse) {
    console.log(err);
    let message = "Error!";
    if (err.status === 0) {
      message = "API is not avaible...";
    } else if (err.status === 404) {
      message = "API is not avaible...";
    }else if (err.status === 500) {
      message = "";
      for(const e of err.error.errorMessages){
        message + "/n";
      }
    }else if (err.status === 402) {}


    this.swal.callToast(message, "error");

  }
}
