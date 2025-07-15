using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace MahalliyMarket.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    category_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    image_url = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    parent_category_id = table.Column<int>(type: "int", nullable: true),
                    sort_order = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.category_id);
                    table.ForeignKey(
                        name: "FK_categories_categories_parent_category_id",
                        column: x => x.parent_category_id,
                        principalTable: "categories",
                        principalColumn: "category_id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "statuses",
                columns: table => new
                {
                    status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    status_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statuses", x => x.status_id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    first_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    middle_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    password_hash = table.Column<byte[]>(type: "longblob", nullable: false),
                    password_salt = table.Column<byte[]>(type: "longblob", nullable: false),
                    role = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    phone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    date_birth = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    province = table.Column<string>(type: "longtext", nullable: true),
                    city_district = table.Column<string>(type: "longtext", nullable: true),
                    mahalla = table.Column<string>(type: "longtext", nullable: true),
                    street = table.Column<string>(type: "longtext", nullable: true),
                    postal_code = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    longitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "carts",
                columns: table => new
                {
                    cart_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    cart_type = table.Column<int>(type: "int", nullable: false),
                    total_items = table.Column<int>(type: "int", nullable: false),
                    total_quantity = table.Column<int>(type: "int", nullable: false),
                    subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    total_discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    tax_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    delivery_cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    total_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    currency = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    is_purchased = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    purchased_at = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carts", x => x.cart_id);
                    table.ForeignKey(
                        name: "FK_carts_users_customer_id",
                        column: x => x.customer_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "delivery_addresses",
                columns: table => new
                {
                    address_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    address_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    recipient_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    phone_number = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    province = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    city_district = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    mahalla = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_delivery_addresses", x => x.address_id);
                    table.ForeignKey(
                        name: "FK_delivery_addresses_users_customer_id",
                        column: x => x.customer_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "product_images",
                columns: table => new
                {
                    image_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    image_url = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    alt_text = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    display_order = table.Column<int>(type: "int", nullable: false),
                    is_primary = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    file_size = table.Column<long>(type: "bigint", nullable: true),
                    mime_type = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    width = table.Column<int>(type: "int", nullable: true),
                    height = table.Column<int>(type: "int", nullable: true),
                    caption = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    uploaded_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_images", x => x.image_id);
                    table.ForeignKey(
                        name: "FK_product_images_users_uploaded_by",
                        column: x => x.uploaded_by,
                        principalTable: "users",
                        principalColumn: "id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "longtext", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Haqiqiy qiymayni olish uchun 1000ga ko'paytirib oling."),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    tags = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    discount_percentage = table.Column<int>(type: "int", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    product_image_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                    table.ForeignKey(
                        name: "FK_products_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_products_product_images_product_image_id",
                        column: x => x.product_image_id,
                        principalTable: "product_images",
                        principalColumn: "image_id");
                    table.ForeignKey(
                        name: "FK_products_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "advertisements",
                columns: table => new
                {
                    ads_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    ads_title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    ads_text = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    ads_image = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    priority = table.Column<int>(type: "int", nullable: false),
                    ads_type = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    view_count = table.Column<int>(type: "int", nullable: false),
                    click_count = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_advertisements", x => x.ads_id);
                    table.ForeignKey(
                        name: "FK_advertisements_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_advertisements_users_created_by",
                        column: x => x.created_by,
                        principalTable: "users",
                        principalColumn: "id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cart_items",
                columns: table => new
                {
                    cart_item_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    cart_id = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    seller_id = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    unit_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    total_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    discount_percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    discount_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    final_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    estimated_delivery_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    added_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    expires_at = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cart_items", x => x.cart_item_id);
                    table.ForeignKey(
                        name: "FK_cart_items_carts_cart_id",
                        column: x => x.cart_id,
                        principalTable: "carts",
                        principalColumn: "cart_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cart_items_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cart_items_users_seller_id",
                        column: x => x.seller_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "delivery_methods",
                columns: table => new
                {
                    delivery_method_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    seller_id = table.Column<int>(type: "int", nullable: false),
                    method_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    is_free_delivery = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    delivery_fee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    can_install = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    installation_fee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    delivery_days = table.Column<int>(type: "int", nullable: false),
                    max_weight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Productid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_delivery_methods", x => x.delivery_method_id);
                    table.ForeignKey(
                        name: "FK_delivery_methods_products_Productid",
                        column: x => x.Productid,
                        principalTable: "products",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_delivery_methods_users_seller_id",
                        column: x => x.seller_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "product_hots",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    priority = table.Column<int>(type: "int", nullable: false),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    expires_at = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    tag = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_hots", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_hots_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "product_swipers",
                columns: table => new
                {
                    swiper_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    seller_id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    subtitle = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    swiper_type = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    swiper_category = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    image_url = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    display_order = table.Column<int>(type: "int", nullable: false),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    end_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    view_count = table.Column<int>(type: "int", nullable: false),
                    click_count = table.Column<int>(type: "int", nullable: false),
                    seo_title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    seo_description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    alt_text = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_swipers", x => x.swiper_id);
                    table.ForeignKey(
                        name: "FK_product_swipers_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_swipers_users_seller_id",
                        column: x => x.seller_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "product_videos",
                columns: table => new
                {
                    video_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    video_url = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    video_title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    video_description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    thumbnail_url = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    display_order = table.Column<int>(type: "int", nullable: false),
                    is_primary = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    duration_seconds = table.Column<int>(type: "int", nullable: true),
                    file_size = table.Column<long>(type: "bigint", nullable: true),
                    mime_type = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    video_quality = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    video_format = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    view_count = table.Column<int>(type: "int", nullable: false),
                    platform_type = table.Column<int>(type: "int", nullable: false),
                    external_video_id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    uploaded_by = table.Column<int>(type: "int", nullable: true),
                    Productid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_videos", x => x.video_id);
                    table.ForeignKey(
                        name: "FK_product_videos_products_Productid",
                        column: x => x.Productid,
                        principalTable: "products",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_product_videos_users_uploaded_by",
                        column: x => x.uploaded_by,
                        principalTable: "users",
                        principalColumn: "id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    order_number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    order_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    delivery_address_id = table.Column<int>(type: "int", nullable: false),
                    total_base_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    total_discount_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    delivery_cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    delivery_method_id = table.Column<int>(type: "int", nullable: true),
                    order_status = table.Column<int>(type: "int", nullable: false),
                    total_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    currency = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false),
                    expected_delivery_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_orders_delivery_addresses_delivery_address_id",
                        column: x => x.delivery_address_id,
                        principalTable: "delivery_addresses",
                        principalColumn: "address_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_delivery_methods_delivery_method_id",
                        column: x => x.delivery_method_id,
                        principalTable: "delivery_methods",
                        principalColumn: "delivery_method_id");
                    table.ForeignKey(
                        name: "FK_orders_users_customer_id",
                        column: x => x.customer_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cancellations",
                columns: table => new
                {
                    cancellation_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    order_id = table.Column<int>(type: "int", nullable: false),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    seller_id = table.Column<int>(type: "int", nullable: false),
                    reason = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    status = table.Column<string>(type: "longtext", nullable: false),
                    requested_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    processed_at = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    processed_by = table.Column<int>(type: "int", nullable: true),
                    refund_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    remarks = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cancellations", x => x.cancellation_id);
                    table.ForeignKey(
                        name: "FK_cancellations_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cancellations_users_customer_id",
                        column: x => x.customer_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cancellations_users_processed_by",
                        column: x => x.processed_by,
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_cancellations_users_seller_id",
                        column: x => x.seller_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "order_items",
                columns: table => new
                {
                    order_item_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    order_id = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    seller_id = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    unit_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    discount_percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    final_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    product_name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    product_image_url = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_items", x => x.order_item_id);
                    table.ForeignKey(
                        name: "FK_order_items_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_items_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_items_users_seller_id",
                        column: x => x.seller_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    payment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    order_id = table.Column<int>(type: "int", nullable: false),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    currency = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false),
                    payment_method = table.Column<int>(type: "int", nullable: false),
                    payment_status = table.Column<int>(type: "int", nullable: false),
                    transaction_id = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    reference_number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    payment_gateway = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    bank_account = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    card_last_four = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: true),
                    card_type = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    processing_fee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    tax_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    exchange_rate = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    base_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    payment_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    processed_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    refunded_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    failure_reason = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    payment_notes = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.payment_id);
                    table.ForeignKey(
                        name: "FK_payments_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_payments_users_customer_id",
                        column: x => x.customer_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "product_feedbacks",
                columns: table => new
                {
                    feedback_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: false),
                    comment_text = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false),
                    is_verified_purchase = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    is_helpful = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    helpful_count = table.Column<int>(type: "int", nullable: false),
                    not_helpful_count = table.Column<int>(type: "int", nullable: false),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    is_approved = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    moderation_notes = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    order_id = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    moderated_at = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    moderated_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_feedbacks", x => x.feedback_id);
                    table.ForeignKey(
                        name: "FK_product_feedbacks_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "order_id");
                    table.ForeignKey(
                        name: "FK_product_feedbacks_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_feedbacks_users_moderated_by",
                        column: x => x.moderated_by,
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_product_feedbacks_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "product_sales",
                columns: table => new
                {
                    sales_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    sale_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    unit_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    total_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    discount_percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    discount_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    final_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    seller_id = table.Column<int>(type: "int", nullable: false),
                    order_id = table.Column<int>(type: "int", nullable: true),
                    payment_method = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    payment_status = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    sales_channel = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    sale_location = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    sale_notes = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    is_refunded = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    refunded_at = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_sales", x => x.sales_id);
                    table.ForeignKey(
                        name: "FK_product_sales_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "order_id");
                    table.ForeignKey(
                        name: "FK_product_sales_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_sales_users_customer_id",
                        column: x => x.customer_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_sales_users_seller_id",
                        column: x => x.seller_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "refunds",
                columns: table => new
                {
                    refund_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    cancellation_id = table.Column<int>(type: "int", nullable: false),
                    order_id = table.Column<int>(type: "int", nullable: false),
                    payment_id = table.Column<int>(type: "int", nullable: false),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    seller_id = table.Column<int>(type: "int", nullable: false),
                    original_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    refund_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    processing_fee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    net_refund_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    reason = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    status = table.Column<string>(type: "longtext", nullable: false),
                    refund_method = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    requested_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    approved_at = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    processed_at = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    completed_at = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    approved_by = table.Column<int>(type: "int", nullable: true),
                    processed_by = table.Column<int>(type: "int", nullable: true),
                    transaction_id = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    reference_number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    bank_account = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    bank_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    card_last_four = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: true),
                    refund_type = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    is_urgent = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    notes = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true),
                    customer_notified = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    seller_notified = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    customer_notified_at = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    seller_notified_at = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_refunds", x => x.refund_id);
                    table.ForeignKey(
                        name: "FK_refunds_cancellations_cancellation_id",
                        column: x => x.cancellation_id,
                        principalTable: "cancellations",
                        principalColumn: "cancellation_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_refunds_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_refunds_payments_payment_id",
                        column: x => x.payment_id,
                        principalTable: "payments",
                        principalColumn: "payment_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_refunds_users_approved_by",
                        column: x => x.approved_by,
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_refunds_users_customer_id",
                        column: x => x.customer_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_refunds_users_processed_by",
                        column: x => x.processed_by,
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_refunds_users_seller_id",
                        column: x => x.seller_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_advertisements_created_by",
                table: "advertisements",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "IX_advertisements_product_id",
                table: "advertisements",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_cancellations_customer_id",
                table: "cancellations",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_cancellations_order_id",
                table: "cancellations",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_cancellations_processed_by",
                table: "cancellations",
                column: "processed_by");

            migrationBuilder.CreateIndex(
                name: "IX_cancellations_seller_id",
                table: "cancellations",
                column: "seller_id");

            migrationBuilder.CreateIndex(
                name: "IX_cart_items_cart_id",
                table: "cart_items",
                column: "cart_id");

            migrationBuilder.CreateIndex(
                name: "IX_cart_items_product_id",
                table: "cart_items",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_cart_items_seller_id",
                table: "cart_items",
                column: "seller_id");

            migrationBuilder.CreateIndex(
                name: "IX_carts_customer_id",
                table: "carts",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_categories_parent_category_id",
                table: "categories",
                column: "parent_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_delivery_addresses_customer_id",
                table: "delivery_addresses",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_delivery_methods_Productid",
                table: "delivery_methods",
                column: "Productid");

            migrationBuilder.CreateIndex(
                name: "IX_delivery_methods_seller_id",
                table: "delivery_methods",
                column: "seller_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_items_order_id",
                table: "order_items",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_items_product_id",
                table: "order_items",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_items_seller_id",
                table: "order_items",
                column: "seller_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_customer_id",
                table: "orders",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_delivery_address_id",
                table: "orders",
                column: "delivery_address_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_delivery_method_id",
                table: "orders",
                column: "delivery_method_id");

            migrationBuilder.CreateIndex(
                name: "IX_payments_customer_id",
                table: "payments",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_payments_order_id",
                table: "payments",
                column: "order_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_product_feedbacks_moderated_by",
                table: "product_feedbacks",
                column: "moderated_by");

            migrationBuilder.CreateIndex(
                name: "IX_product_feedbacks_order_id",
                table: "product_feedbacks",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_feedbacks_product_id",
                table: "product_feedbacks",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_feedbacks_user_id",
                table: "product_feedbacks",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_hots_product_id",
                table: "product_hots",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_images_uploaded_by",
                table: "product_images",
                column: "uploaded_by");

            migrationBuilder.CreateIndex(
                name: "IX_product_sales_customer_id",
                table: "product_sales",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_sales_order_id",
                table: "product_sales",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_sales_product_id",
                table: "product_sales",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_sales_seller_id",
                table: "product_sales",
                column: "seller_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_swipers_product_id",
                table: "product_swipers",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_swipers_seller_id",
                table: "product_swipers",
                column: "seller_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_videos_Productid",
                table: "product_videos",
                column: "Productid");

            migrationBuilder.CreateIndex(
                name: "IX_product_videos_uploaded_by",
                table: "product_videos",
                column: "uploaded_by");

            migrationBuilder.CreateIndex(
                name: "IX_products_category_id",
                table: "products",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_products_product_image_id",
                table: "products",
                column: "product_image_id");

            migrationBuilder.CreateIndex(
                name: "IX_products_user_id",
                table: "products",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_refunds_approved_by",
                table: "refunds",
                column: "approved_by");

            migrationBuilder.CreateIndex(
                name: "IX_refunds_cancellation_id",
                table: "refunds",
                column: "cancellation_id");

            migrationBuilder.CreateIndex(
                name: "IX_refunds_customer_id",
                table: "refunds",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_refunds_order_id",
                table: "refunds",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_refunds_payment_id",
                table: "refunds",
                column: "payment_id");

            migrationBuilder.CreateIndex(
                name: "IX_refunds_processed_by",
                table: "refunds",
                column: "processed_by");

            migrationBuilder.CreateIndex(
                name: "IX_refunds_seller_id",
                table: "refunds",
                column: "seller_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "users",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "advertisements");

            migrationBuilder.DropTable(
                name: "cart_items");

            migrationBuilder.DropTable(
                name: "order_items");

            migrationBuilder.DropTable(
                name: "product_feedbacks");

            migrationBuilder.DropTable(
                name: "product_hots");

            migrationBuilder.DropTable(
                name: "product_sales");

            migrationBuilder.DropTable(
                name: "product_swipers");

            migrationBuilder.DropTable(
                name: "product_videos");

            migrationBuilder.DropTable(
                name: "refunds");

            migrationBuilder.DropTable(
                name: "statuses");

            migrationBuilder.DropTable(
                name: "carts");

            migrationBuilder.DropTable(
                name: "cancellations");

            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "delivery_addresses");

            migrationBuilder.DropTable(
                name: "delivery_methods");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "product_images");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
