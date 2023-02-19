
import { Component, Input, OnInit } from '@angular/core';
import { CompoundServiceService } from './compound-service.service';

interface studentList{
  id:number,
  name:string,
}


@Component({
  selector: 'app-compound',
  templateUrl: './compound.component.html',
  styleUrls: ['./compound.component.css'],
  providers:[CompoundServiceService]

})
export class CompoundComponent implements OnInit{
student:studentList[]=[];
  
 
  constructor(private CompoundServiceService:CompoundServiceService){}
  ngOnInit(): void {
     this.student= this.CompoundServiceService.getstudentlist()
  }

}
