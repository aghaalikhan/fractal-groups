import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { filter, map, switchMap, debounceTime, tap, first, takeUntil } from 'rxjs/operators';
import { Observable, Subject } from 'rxjs';
import { Person, Group } from '../models';
import { SearchService } from '../services/search.service';
import { GroupService } from '../services/group.service';

@Component({
  selector: 'app-search-results',
  templateUrl: './search-results.component.html',
  styleUrls: ['./search-results.component.scss']
})
export class SearchResultsComponent implements OnInit, OnDestroy {
  
  
  public persons$: Observable<Person[]>;
  private searchQuery$: Observable<string>;  
  private groups: Group[];  
  private peronsLoaded = false;
  private groupsLoaded = false;
  private destroy$ = new Subject<void>();  

  public get isLoaded() {
    console.log(this.groupsLoaded);
    console.log(this.peronsLoaded);
    return this.peronsLoaded && this.groupsLoaded;
  }


  constructor(
    private searchService: SearchService,
    private route: ActivatedRoute,
    private groupService: GroupService,
    ) { }


  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.unsubscribe();    
  }

  ngOnInit() {
    this.searchQuery$ = this.route.queryParams.pipe(
      filter(x => !!x['query']),
      map(x => x['query'])
    );

    this.persons$ = this.searchQuery$.pipe(        
      switchMap(query => this.searchService.Search(query)
        .pipe(
          tap(() => {
            this.peronsLoaded = true;                     
          })
        )
      ));

    this.searchQuery$.pipe( 
      first(),
      switchMap(() => this.groupService.Get()),
      takeUntil(this.destroy$))
      .subscribe(groups => {
        this.groups = groups;
        this.groupsLoaded = true;
      });      
  }

  public getGroupName(groupId: number): string {
    return this.groups ? this.groups.find(g => g.groupId == groupId).name : '';
  }
}
