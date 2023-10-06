import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditFeaturedArtistsComponent } from './edit-featured-artists.component';

describe('EditFeaturedArtistsComponent', () => {
  let component: EditFeaturedArtistsComponent;
  let fixture: ComponentFixture<EditFeaturedArtistsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [EditFeaturedArtistsComponent]
    });
    fixture = TestBed.createComponent(EditFeaturedArtistsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
