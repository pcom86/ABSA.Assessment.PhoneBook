import { Component, OnInit } from '@angular/core';
import { PhonebookService } from 'src/app/services/phonebook.service';

@Component({
  selector: 'app-phonebook-list',
  templateUrl: './phonebook-list.component.html',
  styleUrls: ['./phonebook-list.component.css']
})
export class PhonebookListComponent implements OnInit {
  phoneBookList: any;
  addPhoneBook = {
    name: ''
  };
  phoneBook = {
    phoneBookId:0,
    name: ''
  };
  currentIndex:0;
  displayStyle = "none";
  submitted = false;
  constructor(private phonebookService: PhonebookService) { }

  ngOnInit() {
    this.getPhoneBookList();
  }
  getPhoneBookList(): void {
    this.phonebookService.getPhonebookList()
      .subscribe(
        phonebooks => {
          this.phoneBookList = phonebooks;
          console.log(phonebooks);
        },
        error => {
          console.log(error);
        });
  }
  openPopup() {
    this.displayStyle = "block";
  }
  closePopup() {
    this.getPhoneBookList();
    this.displayStyle = "none";
  }
  createPhoneBook(): void {
    const data = {
      name: this.addPhoneBook.name   
    };
    this.phonebookService.createPhoneBook(data)
      .subscribe(
        response => {
          console.log(response);
          this.submitted = true;
          
        },
        error => {
          console.log(error);
        });
  }
  setCurrentPhoneBookItem(phoneBook, index): void {
    this.phoneBook = phoneBook;
    this.currentIndex = index;
  }
}
