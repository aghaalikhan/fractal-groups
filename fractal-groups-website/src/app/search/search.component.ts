import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit {

  public minQueryLength= 3;
  public searchControl: FormControl;
  public get placeholderText() {
    return this.searchControl.value ? '' : 'Please enter seacrch term'
  }
  
  constructor(private router: Router) { }

  ngOnInit() {    
    this.searchControl = new FormControl('', [Validators.required, Validators.minLength(this.minQueryLength)]);
  }

  public onSubmit(): void {

    if(this.searchControl.invalid) {
      return;
    }    

    this.router.navigateByUrl(`search-results?query=${this.searchControl.value}`);
  }
}
