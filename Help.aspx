<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Help.aspx.cs" Inherits="bp2.Help" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        li, li p{
            font-size:16pt;
            line-height: 1.7;
            margin: 15px 0 15px 0;
        }

        .main {
            list-style: none;
            counter-reset: item;
        }

        .main>li {
            counter-increment: item;
            margin-bottom: 5px;
        }

            .main>li:before {
                margin-right: 10px;
                content: counter(item);
                font-size: 24pt !important;
                text-align: center;
                display: inline-block;
            }
    
        h3{
            display: inline;
        }

        p{
            margin-left: 20px !important;
        }
            
    </style>
    <div class="padded-box">
        <div class="narrow">


            <h1 class="title">How our site works</h1>
            <ol class="main">
                <li>
                    <h3>Find a recipe</h3>
                    <ul>
                        <li>Search for a recipe by name(chicken paprikash, ossobuco...), cooking method(one pot, roast...), ingredient(carrots, pork loin...), diet type(gluten free...), or category(fast, easy, weeknight, entertaining...) 
                        </li>
                        <li>Browse our list of categories such as: Breads, Breakfast, Brunch, Chicken, Comfort, Cook Ahead, Dessert, Dinner, Easy...
                        </li>
                        <li>Browse our full recipe list and sort by name, rating, or popularity.
                        </li>
                        <li>View a recipe's related recipes for ideas round out your meal or cook later with leftover ingredients.
                        </li>
                    </ul>
                </li>
                <li>
                    <h3>Change the yield for your needs.</h3>                    
                    <ul>
                        <li>Increase yield for leftovers or big appetites.
                        </li>
                        <li>Use caution when changing baking recipes. Its best to follow them as listed.
                        </li>
                        <li>Change recipes marked with "Recipe amounts are approximate" to your heart's content.
                        </li>
                        <li>Some ingredient amounts might look strange after changing yield. Go ahead and use a whole bell pepper if the recipe calls for 4/5.
                        </li>
                    </ul>
                </li>
                <li>
                    <h3>Compare prices</h3>
                    <p>
                        No Brainer Meals shows price comparisons from select grocery stores. 
                        We show you the price per serving and what your cart total will be. 
                        The price per serving is calculated on the amount of the ingredient you use divided by the number of servings. 
                    </p>                    
                <br />
                </li>
                <li>
                    <h3>Get your ingredients</h3>
                    <ul style="list-style: none;">
                        <li>
                            <h4>By Online Shopping:</h4>
                            <p>
                                Many grocery stores now offer great online shopping! 
                                You buy online and they do the shopping. 
                                Most allow you to pick up at a time that works for you while some even offer home delivery!
                            </p>                            
                            <ol>
                                <li>
                                    Select the grocery store on our recipe page to view the correct shopping list.
                                </li>
                                <li>
                                    Click the link for each ingredient you want to buy.
                                </li>
                                <li>
                                    Add enough of the item to your cart for the recipe.
                                </li>
                                <li>
                                    Go ahead and close the grocery store tab in your browser. The grocery store will remember your list.
                                </li>
                                <li>
                                    After adding the last item, click "check out" at the grocery store's website.
                                </li>
                            </ol>
                       
                            <strong>Tips:</strong>
                            <ul>
                                <li>
                                    Pick your personal favorite brand item instead of our suggested one. 
                                    It will likely show up in the grocery store's similar items section.
                                </li>
                                <li>
                                    The grocery store may be out of our suggested item. 
                                    Just pick a different item from their similar items list.
                                </li>
                                <li>
                                    Close the grocery store's tab in your browser after you have added enough of the item to your cart. 
                                    They will remember you and your order.
                                </li>
                                <li>
                                    Pick several of our recipes to cook this week and add all the ingredients to your cart with this same process before you check out. 
                                </li>
                                <li>
                                    Add toothpaste, paper towels, and breakfast cereal to your order and finish out your whole weekly shopping list. 
                                    You may never go back to the grocery store again!
                                </li>
                            </ul>
                        </li>
                        <li>
                            <h4>Or Printable / Mobile Shopping Lists:</h4>
                            <p>
                                If your local stores don't offer this service yet we will still help you make your shopping list.
                                Select the "printable list" link and print or open on your mobile phone!
                            </p>                            
                        </li>
                    </ul>
                </li>
                <li>
                    <h3>Cook and enjoy your meal!</h3>
                </li>
                <li>
                    <h3>Sign up for a No Brainer Meals Account</h3>
                    <p>
                        That's right, sign up AFTER you use our service.
                    </p>
                    <p>
                        We want our main service to be free to users. 
                        A No Brainer Meals account allows you to make a list of favorite recipes, rate, and comment.
                    </p>
                    <p>
                        We do plan to make an income from commissions, ads, or premium services in the future. 
                        We want to be upfront with you and make build a service that will help both you and us.
                    </p>                    
                </li>
                <li>
                    <h3>Send us feedback!</h3>
                    <p>
                        We would love to know your thoughts about our recipes. Leave a comment on the recipe page. 
                    </p>                    
                    <ul>
                        <li>
                            How did they turn out?
                        </li>
                        <li>
                            Did your picky eater like them?
                        </li>
                        <li>
                            What substitute ingredients did you use?
                        </li>
                    </ul>
                    <p>
                        We would love for you to send us an email at NoBrainerTeam@nobrainermeals.com with any comments, questions, or concerns.
                    </p>                    
                </li>
            </ol>

        </div>
    </div>
</asp:Content>
