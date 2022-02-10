using Microsoft.EntityFrameworkCore;
using Users.User.domain;
using Users.User.infraestructure.Persistence.Contexts;

namespace Users.User.infraestructure.Persistence;

public class DataSeeder
{
    private readonly IUserRepository _userRepository;    
    private readonly UserContext _context;

    public DataSeeder(
        IUserRepository userRepository,        
        UserContext context
    )
    {
        _userRepository = userRepository;
        _context = context;
    }

    public void Seed()
    {
        EnsuredDatabase();
        EnsuredUsers();      
    }

    private void EnsuredDatabase()
    {
        _context.Database.Migrate();
    }

    private void EnsuredUsers()
    {
        domain.User erick = domain.User.Create(
            id: new UserId(new Guid("6176dfdd-a00c-45ba-ad3e-b11f46c34c6c")),
            userName: new UserName("Erick")
        );
        domain.User daniel = domain.User.Create(
            id: new UserId(new Guid("f8a5b841-5e7a-4723-96cb-e533a79458dc")),
            userName: new UserName("Daniel")
        );
        domain.User damian = domain.User.Create(
            id: new UserId(new Guid("6c34ea46-be3f-4eae-b3fe-e772a5f5388f")),
            userName: new UserName("Damian")
        );
        domain.User raul = domain.User.Create(
            id: new UserId(new Guid("f6a06db5-9d5d-48c3-bbd6-b7d41c9dd0b1")),
            userName: new UserName("Raul")
        );

        if (!_customerRepository.Exists(new Guid("6176dfdd-a00c-45ba-ad3e-b11f46c34c6c"))) { _customerRepository.Insert(erick); }
        if (!_customerRepository.Exists(new Guid("f8a5b841-5e7a-4723-96cb-e533a79458dc"))) { _customerRepository.Insert(daniel); }
        if (!_customerRepository.Exists(new Guid("6c34ea46-be3f-4eae-b3fe-e772a5f5388f"))) { _customerRepository.Insert(raul); }
        if (!_customerRepository.Exists(new Guid("f6a06db5-9d5d-48c3-bbd6-b7d41c9dd0b1"))) { _customerRepository.Insert(damian); }

        _customerRepository.Save();
    }

    private void EnsuredProducts()
    {
        Product monitor = Product.Create(
            id: new ProductId(new Guid("3609a10a-c344-4a1b-b1e9-192de5594d29")),
            idParent: null,
            name: new ProductName("Monitor"),
            description: new ProductDescription("Monitor 24 LG"),
            price: new ProductPrice((decimal)120.8),
            stock: new ProductStock(0),
            gift: new ProductGift(false)
        );
        Product keyboard = Product.Create(
            id: new ProductId(new Guid("c3a8ce0a-ff2f-4106-a56c-2e101ae15b93")),
            idParent: null,
            name: new ProductName("Keyboard"),
            description: new ProductDescription("Keyboard Logitech"),
            price: new ProductPrice((decimal)20.5),
            stock: new ProductStock(0),
            gift: new ProductGift(false)
        );
        Product mouse = Product.Create(
            id: new ProductId(new Guid("68f884eb-3367-49af-9a3c-055f1ad27a2e")),
            idParent: new ProductId(new Guid("c3a8ce0a-ff2f-4106-a56c-2e101ae15b93")),
            name: new ProductName("Mouse"),
            description: new ProductDescription("Mouse Logitech"),
            price: new ProductPrice((decimal)10.5),
            stock: new ProductStock(0),
            gift: new ProductGift(true)
        );
        if (!_productRepository.Exists(new Guid("3609a10a-c344-4a1b-b1e9-192de5594d29"))) { _productRepository.Insert(monitor); }
        if (!_productRepository.Exists(new Guid("c3a8ce0a-ff2f-4106-a56c-2e101ae15b93"))) { _productRepository.Insert(keyboard); }
        if (!_productRepository.Exists(new Guid("68f884eb-3367-49af-9a3c-055f1ad27a2e"))) { _productRepository.Insert(mouse); }

        _productRepository.Save();
    }

    private void EnsuredDiscountCoupon()
    {
        DiscountCoupon discountCoupon01 = DiscountCoupon.Create(
            id: new DiscountCouponId(new Guid("06ed9c55-b9c9-46eb-80e9-e28a87c65950")),
            code: new DiscountCouponCode("DISCOUNT-01"),
            description:new DiscountCouponDescription("Descuento 01"),
            discountCouponType:DiscountCouponType.Percentage,
            discountValue:new DiscountCouponValue(50),
            minimumAmount:new DiscountCouponMinimumAmount(200)
        );
        DiscountCoupon discountCoupon02 = DiscountCoupon.Create(
            id: new DiscountCouponId(new Guid("6662daaa-2d4c-4f73-bb08-3a97c6a584ec")),
            code: new DiscountCouponCode("DISCOUNT-02"),
            description: new DiscountCouponDescription("Descuento 02"),
            discountCouponType: DiscountCouponType.Amount,
            discountValue: new DiscountCouponValue(10),
            minimumAmount: new DiscountCouponMinimumAmount(100)
        );

        if (!_discountRepository.Exists(new Guid("06ed9c55-b9c9-46eb-80e9-e28a87c65950"))) { _discountRepository.Insert(discountCoupon01); }
        if (!_discountRepository.Exists(new Guid("6662daaa-2d4c-4f73-bb08-3a97c6a584ec"))) { _discountRepository.Insert(discountCoupon02); }        

        _discountRepository.Save();
    }

    private void EnsuredCarts()
    {
        Customer erick = _customerRepository.FindById(new Guid("6176dfdd-a00c-45ba-ad3e-b11f46c34c6c"));
        Customer daniel = _customerRepository.FindById(new Guid("f8a5b841-5e7a-4723-96cb-e533a79458dc"));
        Customer raul = _customerRepository.FindById(new Guid("6c34ea46-be3f-4eae-b3fe-e772a5f5388f"));
        Customer damian = _customerRepository.FindById(new Guid("f6a06db5-9d5d-48c3-bbd6-b7d41c9dd0b1"));

        Product monitor = _productRepository.FindById(new Guid("3609a10a-c344-4a1b-b1e9-192de5594d29"));
        Product keyboard = _productRepository.FindById(new Guid("c3a8ce0a-ff2f-4106-a56c-2e101ae15b93"));        
        Product mouse = _productRepository.FindById(new Guid("68f884eb-3367-49af-9a3c-055f1ad27a2e"));         
        
        Cart emptyCartErick = Cart.CreateEmptyCart(
            id: new CartId(new Guid("60e604ba-8f9f-4689-8fcb-f19add81cda2")),
            customer: erick,
            state:CartState.Created
        );
        Cart emptyCartDaniel = Cart.CreateEmptyCart(
            id: new CartId(new Guid("09714cb8-14de-4c6e-8d68-76403304ae12")),
            customer: daniel,
            state: CartState.Created
        );
        Cart emptyCartRaul = Cart.CreateEmptyCart(
            id: new CartId(new Guid("ef1318e3-8674-4263-a1c1-79001b3b5c02")),
            customer: raul,
            state: CartState.Created
        );
        Cart emptyCartDamian = Cart.CreateEmptyCart(
            id: new CartId(new Guid("f10ce641-0ab3-45bf-b335-8f6c331a54a8")),
            customer: damian,
            state: CartState.Created
        );

        PurchasedProduct purchasedProductMonitorErick = PurchasedProduct.CreateWithoutId(
            cart: emptyCartErick,
            product:monitor,
            quantity: new PurchasedProductQuantity(1)
        );
        PurchasedProduct purchasedProductKeyboardErick = PurchasedProduct.CreateWithoutId(
            cart: emptyCartErick,
            product: keyboard,
            quantity: new PurchasedProductQuantity(2)
        );
        PurchasedProduct purchasedProductMouseErick = PurchasedProduct.CreateWithoutId(
            cart: emptyCartErick,
            product: mouse,
            quantity: new PurchasedProductQuantity(3)
        );

        PurchasedProduct purchasedProductMonitorDaniel = PurchasedProduct.CreateWithoutId(
            cart: emptyCartDaniel,
            product: monitor,
            quantity: new PurchasedProductQuantity(50)
        );
        PurchasedProduct purchasedProductKeyboardRaul = PurchasedProduct.CreateWithoutId(
            cart: emptyCartRaul,
            product: keyboard,
            quantity: new PurchasedProductQuantity(50)
        );
        PurchasedProduct purchasedProductMouseDamian = PurchasedProduct.CreateWithoutId(
            cart: emptyCartDamian,
            product: mouse,
            quantity: new PurchasedProductQuantity(30)
        );

        DiscountCoupon discountCouponDaniel = _discountRepository.FindById(new Guid("06ed9c55-b9c9-46eb-80e9-e28a87c65950"));
        DiscountCoupon discountCouponRaul = _discountRepository.FindById(new Guid("6662daaa-2d4c-4f73-bb08-3a97c6a584ec"));

        emptyCartErick.PurchasedProducts.Add(purchasedProductMonitorErick);
        emptyCartErick.PurchasedProducts.Add(purchasedProductKeyboardErick);
        emptyCartErick.PurchasedProducts.Add(purchasedProductMouseErick);

        emptyCartDaniel.PurchasedProducts.Add(purchasedProductMonitorDaniel);
        emptyCartDaniel.AddCoupon(discountCouponDaniel);

        emptyCartRaul.PurchasedProducts.Add(purchasedProductKeyboardRaul);
        emptyCartRaul.AddCoupon(discountCouponRaul);

        emptyCartDamian.PurchasedProducts.Add(purchasedProductMouseDamian);

        if (_cartRepository.FindById(new Guid("60e604ba-8f9f-4689-8fcb-f19add81cda2")) == null) { _cartRepository.Insert(emptyCartErick); }
        if (_cartRepository.FindById(new Guid("09714cb8-14de-4c6e-8d68-76403304ae12")) == null) { _cartRepository.Insert(emptyCartDaniel); }
        if (_cartRepository.FindById(new Guid("ef1318e3-8674-4263-a1c1-79001b3b5c02")) == null) { _cartRepository.Insert(emptyCartRaul); }
        if (_cartRepository.FindById(new Guid("f10ce641-0ab3-45bf-b335-8f6c331a54a8")) == null) { _cartRepository.Insert(emptyCartDamian); }

        _cartRepository.Save();
    }
}
