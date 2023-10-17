import { AfterViewInit, Component, ElementRef, ViewChild, ViewEncapsulation } from '@angular/core';
import { ArticleClient, ArticleDTO } from 'src/api.generated.clients';

@Component({
  selector: 'app-article-template',
  templateUrl: './article-template.component.html',
  styleUrls: ['./article-template.component.scss'],
  encapsulation: ViewEncapsulation.None,
  providers: [ArticleClient]
})
export class ArticleTemplateComponent implements AfterViewInit {

  public article: ArticleDTO = new ArticleDTO();
  //Swap to viewChild?
  public templateDiv: HTMLElement | null = null;

  constructor(private articleClient: ArticleClient) {

  }

  ngAfterViewInit() {
    this.templateDiv = document.getElementById('templateDiv')
    this.getArticle(1);
  }

  getArticle(id: number) {
    this.articleClient.get(id).subscribe({
    next: (res) => {
      this.article = res
      this.insertImgElements();
      this.templateDiv!.insertAdjacentHTML('beforeend', this.article.text);
    },
    error: (error) => this.templateDiv?.insertAdjacentHTML('beforeend', "Sorry, an error occurred while loading your article!")
    });
  }

  insertImgElements() {

    let maxImages = 20;

    for (let i = 0; i < this.article.imgSrcs.length && i < maxImages; i++) {
      this.article.text = this.article.text.replace(`<Image[${i}]>`, `<img src=\"assets/query_projection/${this.article.imgSrcs[i]}\" class=\"template-img\">`)
    }
    
  }

}
