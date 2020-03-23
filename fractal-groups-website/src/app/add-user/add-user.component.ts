import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Group } from '../models';
import { Observable, Subject } from 'rxjs';
import { GroupService } from '../services/group.service';
import { tap, takeUntil } from 'rxjs/operators';
import { PersonService } from '../services/person.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.scss']
})
export class AddUserComponent implements OnInit, OnDestroy {

  public minNameLength = 2;
  public isBusy = true;
  public userForm: FormGroup;
  public groups$: Observable<Group[]>
  public destroy$ = new Subject<void>();

  constructor(
    private groupService: GroupService, 
    private personService: PersonService,
    private router: Router) { }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.unsubscribe();
  }

  ngOnInit() {
    this.userForm = new FormGroup({
      firstName: new FormControl('', [Validators.required]),
      lastName: new FormControl('', [Validators.required]),
      groupId: new FormControl('', [Validators.required]) ,
    })

    this.groups$ = this.groupService.Get().pipe(   
      tap(() => this.isBusy = false));
  }

  public onSubmit() {    
    this.personService.AddPerson(this.userForm.value).pipe(
      takeUntil(this.destroy$),
      tap(() => this.router.navigate(['']))).subscribe();   
  }
}
