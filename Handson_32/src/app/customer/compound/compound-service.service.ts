import { Injectable, Optional } from '@angular/core';
interface studentList{
  id:number,
  name:string,
}
@Injectable(
  {
    providedIn: 'root'
  }
)
export class CompoundServiceService {
  student:studentList[]=[
    {
      id:2,
      name:'vinodh'
    }
    ,{
      id:6,
      name:'binsmms'
    }
  ];
 
  constructor() { 
    console.log("usiiisiioos")
  }
  getstudentlist()
  {
    return this.student
  
  }
}
