-- MySQL dump 10.13  Distrib 8.0.32, for Win64 (x86_64)
--
-- Host: 192.168.0.252    Database: mahalliy_market
-- ------------------------------------------------------
-- Server version	8.0.35

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) COLLATE utf8mb4_general_ci NOT NULL,
  `ProductVersion` varchar(32) COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` VALUES ('20250717100744_InitialCreate','8.0.0'),('20250717101333_AddedUserIsActive','8.0.0');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `advertisements`
--

DROP TABLE IF EXISTS `advertisements`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `advertisements` (
  `ads_id` int NOT NULL AUTO_INCREMENT,
  `product_id` int NOT NULL,
  `ads_title` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `ads_text` varchar(500) COLLATE utf8mb4_general_ci NOT NULL,
  `ads_image` varchar(255) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `is_active` tinyint(1) NOT NULL,
  `start_date` datetime(6) NOT NULL,
  `end_date` datetime(6) NOT NULL,
  `priority` int NOT NULL,
  `ads_type` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `view_count` int NOT NULL,
  `click_count` int NOT NULL,
  `created_at` datetime(6) NOT NULL,
  `updated_at` datetime(6) NOT NULL,
  `created_by` int DEFAULT NULL,
  PRIMARY KEY (`ads_id`),
  KEY `IX_advertisements_created_by` (`created_by`),
  KEY `IX_advertisements_product_id` (`product_id`),
  CONSTRAINT `FK_advertisements_products_product_id` FOREIGN KEY (`product_id`) REFERENCES `products` (`id`) ON DELETE CASCADE,
  CONSTRAINT `FK_advertisements_users_created_by` FOREIGN KEY (`created_by`) REFERENCES `users` (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `advertisements`
--

LOCK TABLES `advertisements` WRITE;
/*!40000 ALTER TABLE `advertisements` DISABLE KEYS */;
/*!40000 ALTER TABLE `advertisements` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cancellations`
--

DROP TABLE IF EXISTS `cancellations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cancellations` (
  `cancellation_id` int NOT NULL AUTO_INCREMENT,
  `order_id` int NOT NULL,
  `customer_id` int NOT NULL,
  `seller_id` int NOT NULL,
  `reason` varchar(500) COLLATE utf8mb4_general_ci NOT NULL,
  `status` longtext COLLATE utf8mb4_general_ci NOT NULL,
  `requested_at` datetime(6) NOT NULL,
  `processed_at` datetime(6) DEFAULT NULL,
  `processed_by` int DEFAULT NULL,
  `refund_amount` decimal(18,2) NOT NULL,
  `remarks` varchar(1000) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `created_at` datetime(6) NOT NULL,
  PRIMARY KEY (`cancellation_id`),
  KEY `IX_cancellations_customer_id` (`customer_id`),
  KEY `IX_cancellations_order_id` (`order_id`),
  KEY `IX_cancellations_processed_by` (`processed_by`),
  KEY `IX_cancellations_seller_id` (`seller_id`),
  CONSTRAINT `FK_cancellations_orders_order_id` FOREIGN KEY (`order_id`) REFERENCES `orders` (`order_id`) ON DELETE CASCADE,
  CONSTRAINT `FK_cancellations_users_customer_id` FOREIGN KEY (`customer_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE,
  CONSTRAINT `FK_cancellations_users_processed_by` FOREIGN KEY (`processed_by`) REFERENCES `users` (`user_id`),
  CONSTRAINT `FK_cancellations_users_seller_id` FOREIGN KEY (`seller_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cancellations`
--

LOCK TABLES `cancellations` WRITE;
/*!40000 ALTER TABLE `cancellations` DISABLE KEYS */;
/*!40000 ALTER TABLE `cancellations` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cart_items`
--

DROP TABLE IF EXISTS `cart_items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cart_items` (
  `cart_item_id` int NOT NULL AUTO_INCREMENT,
  `cart_id` int NOT NULL,
  `product_id` int NOT NULL,
  `seller_id` int NOT NULL,
  `quantity` int NOT NULL,
  `unit_price` decimal(18,2) NOT NULL,
  `total_price` decimal(18,2) NOT NULL,
  `discount_percentage` decimal(18,2) NOT NULL,
  `discount_amount` decimal(18,2) NOT NULL,
  `final_price` decimal(18,2) NOT NULL,
  `estimated_delivery_date` datetime(6) DEFAULT NULL,
  `added_at` datetime(6) NOT NULL,
  `updated_at` datetime(6) NOT NULL,
  `expires_at` datetime(6) DEFAULT NULL,
  PRIMARY KEY (`cart_item_id`),
  KEY `IX_cart_items_cart_id` (`cart_id`),
  KEY `IX_cart_items_product_id` (`product_id`),
  KEY `IX_cart_items_seller_id` (`seller_id`),
  CONSTRAINT `FK_cart_items_carts_cart_id` FOREIGN KEY (`cart_id`) REFERENCES `carts` (`cart_id`) ON DELETE CASCADE,
  CONSTRAINT `FK_cart_items_products_product_id` FOREIGN KEY (`product_id`) REFERENCES `products` (`id`) ON DELETE CASCADE,
  CONSTRAINT `FK_cart_items_users_seller_id` FOREIGN KEY (`seller_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cart_items`
--

LOCK TABLES `cart_items` WRITE;
/*!40000 ALTER TABLE `cart_items` DISABLE KEYS */;
/*!40000 ALTER TABLE `cart_items` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `carts`
--

DROP TABLE IF EXISTS `carts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `carts` (
  `cart_id` int NOT NULL AUTO_INCREMENT,
  `customer_id` int NOT NULL,
  `cart_type` int NOT NULL,
  `total_items` int NOT NULL,
  `total_quantity` int NOT NULL,
  `subtotal` decimal(18,2) NOT NULL,
  `total_discount` decimal(18,2) NOT NULL,
  `tax_amount` decimal(18,2) NOT NULL,
  `delivery_cost` decimal(18,2) NOT NULL,
  `total_amount` decimal(18,2) NOT NULL,
  `currency` varchar(3) COLLATE utf8mb4_general_ci NOT NULL,
  `is_active` tinyint(1) NOT NULL,
  `is_purchased` tinyint(1) NOT NULL,
  `purchased_at` datetime(6) DEFAULT NULL,
  `created_at` datetime(6) NOT NULL,
  `updated_at` datetime(6) NOT NULL,
  PRIMARY KEY (`cart_id`),
  KEY `IX_carts_customer_id` (`customer_id`),
  CONSTRAINT `FK_carts_users_customer_id` FOREIGN KEY (`customer_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `carts`
--

LOCK TABLES `carts` WRITE;
/*!40000 ALTER TABLE `carts` DISABLE KEYS */;
/*!40000 ALTER TABLE `carts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `categories`
--

DROP TABLE IF EXISTS `categories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categories` (
  `category_id` int NOT NULL AUTO_INCREMENT,
  `category_name` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `description` varchar(500) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `is_active` tinyint(1) NOT NULL,
  `image_url` varchar(255) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `parent_category_id` int DEFAULT NULL,
  `sort_order` int NOT NULL,
  `created_at` datetime(6) NOT NULL,
  `updated_at` datetime(6) NOT NULL,
  PRIMARY KEY (`category_id`),
  KEY `IX_categories_parent_category_id` (`parent_category_id`),
  CONSTRAINT `FK_categories_categories_parent_category_id` FOREIGN KEY (`parent_category_id`) REFERENCES `categories` (`category_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categories`
--

LOCK TABLES `categories` WRITE;
/*!40000 ALTER TABLE `categories` DISABLE KEYS */;
INSERT INTO `categories` VALUES (1,'Mevalar','Turli xildagi mevalar',1,' ',NULL,1,'2025-07-18 08:57:21.000000','2025-07-18 08:57:24.000000');
/*!40000 ALTER TABLE `categories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `delivery_addresses`
--

DROP TABLE IF EXISTS `delivery_addresses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `delivery_addresses` (
  `address_id` int NOT NULL AUTO_INCREMENT,
  `customer_id` int NOT NULL,
  `address_name` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `recipient_name` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `phone_number` varchar(20) COLLATE utf8mb4_general_ci NOT NULL,
  `province` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `city_district` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `mahalla` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
  PRIMARY KEY (`address_id`),
  KEY `IX_delivery_addresses_customer_id` (`customer_id`),
  CONSTRAINT `FK_delivery_addresses_users_customer_id` FOREIGN KEY (`customer_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `delivery_addresses`
--

LOCK TABLES `delivery_addresses` WRITE;
/*!40000 ALTER TABLE `delivery_addresses` DISABLE KEYS */;
/*!40000 ALTER TABLE `delivery_addresses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `delivery_methods`
--

DROP TABLE IF EXISTS `delivery_methods`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `delivery_methods` (
  `delivery_method_id` int NOT NULL AUTO_INCREMENT,
  `seller_id` int NOT NULL,
  `method_name` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `description` varchar(500) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `is_free_delivery` tinyint(1) NOT NULL,
  `delivery_fee` decimal(18,2) NOT NULL,
  `can_install` tinyint(1) NOT NULL,
  `installation_fee` decimal(18,2) NOT NULL,
  `delivery_days` int NOT NULL,
  `max_weight` decimal(18,2) DEFAULT NULL,
  `is_active` tinyint(1) NOT NULL,
  `created_at` datetime(6) NOT NULL,
  `updated_at` datetime(6) DEFAULT NULL,
  `Productid` int DEFAULT NULL,
  PRIMARY KEY (`delivery_method_id`),
  KEY `IX_delivery_methods_Productid` (`Productid`),
  KEY `IX_delivery_methods_seller_id` (`seller_id`),
  CONSTRAINT `FK_delivery_methods_products_Productid` FOREIGN KEY (`Productid`) REFERENCES `products` (`id`),
  CONSTRAINT `FK_delivery_methods_users_seller_id` FOREIGN KEY (`seller_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `delivery_methods`
--

LOCK TABLES `delivery_methods` WRITE;
/*!40000 ALTER TABLE `delivery_methods` DISABLE KEYS */;
/*!40000 ALTER TABLE `delivery_methods` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_items`
--

DROP TABLE IF EXISTS `order_items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `order_items` (
  `order_item_id` int NOT NULL AUTO_INCREMENT,
  `order_id` int NOT NULL,
  `product_id` int NOT NULL,
  `seller_id` int NOT NULL,
  `quantity` int NOT NULL,
  `unit_price` decimal(18,2) NOT NULL,
  `discount_percentage` decimal(18,2) NOT NULL,
  `final_price` decimal(18,2) NOT NULL,
  `product_name` varchar(200) COLLATE utf8mb4_general_ci NOT NULL,
  `product_image_url` varchar(500) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `created_at` datetime(6) NOT NULL,
  PRIMARY KEY (`order_item_id`),
  KEY `IX_order_items_order_id` (`order_id`),
  KEY `IX_order_items_product_id` (`product_id`),
  KEY `IX_order_items_seller_id` (`seller_id`),
  CONSTRAINT `FK_order_items_orders_order_id` FOREIGN KEY (`order_id`) REFERENCES `orders` (`order_id`) ON DELETE CASCADE,
  CONSTRAINT `FK_order_items_products_product_id` FOREIGN KEY (`product_id`) REFERENCES `products` (`id`) ON DELETE CASCADE,
  CONSTRAINT `FK_order_items_users_seller_id` FOREIGN KEY (`seller_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_items`
--

LOCK TABLES `order_items` WRITE;
/*!40000 ALTER TABLE `order_items` DISABLE KEYS */;
/*!40000 ALTER TABLE `order_items` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orders` (
  `order_id` int NOT NULL AUTO_INCREMENT,
  `order_number` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `order_date` datetime(6) NOT NULL,
  `customer_id` int NOT NULL,
  `delivery_address_id` int NOT NULL,
  `total_base_amount` decimal(18,2) NOT NULL,
  `total_discount_amount` decimal(18,2) NOT NULL,
  `delivery_cost` decimal(18,2) NOT NULL,
  `delivery_method_id` int DEFAULT NULL,
  `order_status` int NOT NULL,
  `total_amount` decimal(18,2) NOT NULL,
  `currency` varchar(3) COLLATE utf8mb4_general_ci NOT NULL,
  `expected_delivery_date` datetime(6) DEFAULT NULL,
  `created_at` datetime(6) NOT NULL,
  PRIMARY KEY (`order_id`),
  KEY `IX_orders_customer_id` (`customer_id`),
  KEY `IX_orders_delivery_address_id` (`delivery_address_id`),
  KEY `IX_orders_delivery_method_id` (`delivery_method_id`),
  CONSTRAINT `FK_orders_delivery_addresses_delivery_address_id` FOREIGN KEY (`delivery_address_id`) REFERENCES `delivery_addresses` (`address_id`) ON DELETE CASCADE,
  CONSTRAINT `FK_orders_delivery_methods_delivery_method_id` FOREIGN KEY (`delivery_method_id`) REFERENCES `delivery_methods` (`delivery_method_id`),
  CONSTRAINT `FK_orders_users_customer_id` FOREIGN KEY (`customer_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orders`
--

LOCK TABLES `orders` WRITE;
/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `payments`
--

DROP TABLE IF EXISTS `payments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `payments` (
  `payment_id` int NOT NULL AUTO_INCREMENT,
  `order_id` int NOT NULL,
  `customer_id` int NOT NULL,
  `amount` decimal(18,2) NOT NULL,
  `currency` varchar(3) COLLATE utf8mb4_general_ci NOT NULL,
  `payment_method` int NOT NULL,
  `payment_status` int NOT NULL,
  `transaction_id` varchar(100) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `reference_number` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `payment_gateway` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `bank_account` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `card_last_four` varchar(4) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `card_type` varchar(20) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `processing_fee` decimal(18,2) NOT NULL,
  `tax_amount` decimal(18,2) NOT NULL,
  `exchange_rate` decimal(18,6) DEFAULT NULL,
  `base_amount` decimal(18,2) DEFAULT NULL,
  `payment_date` datetime(6) NOT NULL,
  `processed_date` datetime(6) DEFAULT NULL,
  `refunded_date` datetime(6) DEFAULT NULL,
  `failure_reason` varchar(500) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `payment_notes` varchar(1000) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `is_active` tinyint(1) NOT NULL,
  `created_at` datetime(6) NOT NULL,
  `updated_at` datetime(6) NOT NULL,
  PRIMARY KEY (`payment_id`),
  UNIQUE KEY `IX_payments_order_id` (`order_id`),
  KEY `IX_payments_customer_id` (`customer_id`),
  CONSTRAINT `FK_payments_orders_order_id` FOREIGN KEY (`order_id`) REFERENCES `orders` (`order_id`) ON DELETE CASCADE,
  CONSTRAINT `FK_payments_users_customer_id` FOREIGN KEY (`customer_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payments`
--

LOCK TABLES `payments` WRITE;
/*!40000 ALTER TABLE `payments` DISABLE KEYS */;
/*!40000 ALTER TABLE `payments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product_feedbacks`
--

DROP TABLE IF EXISTS `product_feedbacks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product_feedbacks` (
  `feedback_id` int NOT NULL AUTO_INCREMENT,
  `user_id` int NOT NULL,
  `product_id` int NOT NULL,
  `rating` int NOT NULL,
  `comment_text` varchar(1000) COLLATE utf8mb4_general_ci NOT NULL,
  `is_verified_purchase` tinyint(1) NOT NULL,
  `is_helpful` tinyint(1) NOT NULL,
  `helpful_count` int NOT NULL,
  `not_helpful_count` int NOT NULL,
  `is_active` tinyint(1) NOT NULL,
  `is_approved` tinyint(1) NOT NULL,
  `moderation_notes` varchar(500) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `order_id` int DEFAULT NULL,
  `created_at` datetime(6) NOT NULL,
  `updated_at` datetime(6) NOT NULL,
  `moderated_at` datetime(6) DEFAULT NULL,
  `moderated_by` int DEFAULT NULL,
  PRIMARY KEY (`feedback_id`),
  KEY `IX_product_feedbacks_moderated_by` (`moderated_by`),
  KEY `IX_product_feedbacks_order_id` (`order_id`),
  KEY `IX_product_feedbacks_product_id` (`product_id`),
  KEY `IX_product_feedbacks_user_id` (`user_id`),
  CONSTRAINT `FK_product_feedbacks_orders_order_id` FOREIGN KEY (`order_id`) REFERENCES `orders` (`order_id`),
  CONSTRAINT `FK_product_feedbacks_products_product_id` FOREIGN KEY (`product_id`) REFERENCES `products` (`id`) ON DELETE CASCADE,
  CONSTRAINT `FK_product_feedbacks_users_moderated_by` FOREIGN KEY (`moderated_by`) REFERENCES `users` (`user_id`),
  CONSTRAINT `FK_product_feedbacks_users_user_id` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_feedbacks`
--

LOCK TABLES `product_feedbacks` WRITE;
/*!40000 ALTER TABLE `product_feedbacks` DISABLE KEYS */;
/*!40000 ALTER TABLE `product_feedbacks` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product_hots`
--

DROP TABLE IF EXISTS `product_hots`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product_hots` (
  `id` int NOT NULL AUTO_INCREMENT,
  `product_id` int NOT NULL,
  `priority` int NOT NULL,
  `is_active` tinyint(1) NOT NULL,
  `expires_at` datetime(6) DEFAULT NULL,
  `tag` varchar(200) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `created_at` datetime(6) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `IX_product_hots_product_id` (`product_id`),
  CONSTRAINT `FK_product_hots_products_product_id` FOREIGN KEY (`product_id`) REFERENCES `products` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_hots`
--

LOCK TABLES `product_hots` WRITE;
/*!40000 ALTER TABLE `product_hots` DISABLE KEYS */;
/*!40000 ALTER TABLE `product_hots` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product_images`
--

DROP TABLE IF EXISTS `product_images`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product_images` (
  `image_id` int NOT NULL AUTO_INCREMENT,
  `image_url` varchar(500) COLLATE utf8mb4_general_ci NOT NULL,
  `alt_text` varchar(200) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `display_order` int NOT NULL,
  `is_primary` tinyint(1) NOT NULL,
  `is_active` tinyint(1) NOT NULL,
  `file_size` bigint DEFAULT NULL,
  `mime_type` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `width` int DEFAULT NULL,
  `height` int DEFAULT NULL,
  `caption` varchar(300) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `created_at` datetime(6) NOT NULL,
  `updated_at` datetime(6) NOT NULL,
  `uploaded_by` int DEFAULT NULL,
  PRIMARY KEY (`image_id`),
  KEY `IX_product_images_uploaded_by` (`uploaded_by`),
  CONSTRAINT `FK_product_images_users_uploaded_by` FOREIGN KEY (`uploaded_by`) REFERENCES `users` (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_images`
--

LOCK TABLES `product_images` WRITE;
/*!40000 ALTER TABLE `product_images` DISABLE KEYS */;
/*!40000 ALTER TABLE `product_images` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product_sales`
--

DROP TABLE IF EXISTS `product_sales`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product_sales` (
  `sales_id` int NOT NULL AUTO_INCREMENT,
  `product_id` int NOT NULL,
  `quantity` int NOT NULL,
  `sale_date` datetime(6) NOT NULL,
  `unit_price` decimal(18,2) NOT NULL,
  `total_amount` decimal(18,2) NOT NULL,
  `discount_percentage` decimal(18,2) NOT NULL,
  `discount_amount` decimal(18,2) NOT NULL,
  `final_amount` decimal(18,2) NOT NULL,
  `customer_id` int NOT NULL,
  `seller_id` int NOT NULL,
  `order_id` int DEFAULT NULL,
  `payment_method` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `payment_status` varchar(20) COLLATE utf8mb4_general_ci NOT NULL,
  `sales_channel` varchar(30) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `sale_location` varchar(200) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `sale_notes` varchar(500) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `is_active` tinyint(1) NOT NULL,
  `is_refunded` tinyint(1) NOT NULL,
  `created_at` datetime(6) NOT NULL,
  `updated_at` datetime(6) NOT NULL,
  `refunded_at` datetime(6) DEFAULT NULL,
  PRIMARY KEY (`sales_id`),
  KEY `IX_product_sales_customer_id` (`customer_id`),
  KEY `IX_product_sales_order_id` (`order_id`),
  KEY `IX_product_sales_product_id` (`product_id`),
  KEY `IX_product_sales_seller_id` (`seller_id`),
  CONSTRAINT `FK_product_sales_orders_order_id` FOREIGN KEY (`order_id`) REFERENCES `orders` (`order_id`),
  CONSTRAINT `FK_product_sales_products_product_id` FOREIGN KEY (`product_id`) REFERENCES `products` (`id`) ON DELETE CASCADE,
  CONSTRAINT `FK_product_sales_users_customer_id` FOREIGN KEY (`customer_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE,
  CONSTRAINT `FK_product_sales_users_seller_id` FOREIGN KEY (`seller_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_sales`
--

LOCK TABLES `product_sales` WRITE;
/*!40000 ALTER TABLE `product_sales` DISABLE KEYS */;
/*!40000 ALTER TABLE `product_sales` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product_swipers`
--

DROP TABLE IF EXISTS `product_swipers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product_swipers` (
  `swiper_id` int NOT NULL AUTO_INCREMENT,
  `product_id` int NOT NULL,
  `seller_id` int NOT NULL,
  `title` varchar(200) COLLATE utf8mb4_general_ci NOT NULL,
  `subtitle` varchar(300) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `description` varchar(500) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `swiper_type` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `swiper_category` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `image_url` varchar(500) COLLATE utf8mb4_general_ci NOT NULL,
  `display_order` int NOT NULL,
  `is_active` tinyint(1) NOT NULL,
  `start_date` datetime(6) DEFAULT NULL,
  `end_date` datetime(6) DEFAULT NULL,
  `view_count` int NOT NULL,
  `click_count` int NOT NULL,
  `seo_title` varchar(200) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `seo_description` varchar(500) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `alt_text` varchar(200) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `created_at` datetime(6) NOT NULL,
  `updated_at` datetime(6) NOT NULL,
  PRIMARY KEY (`swiper_id`),
  KEY `IX_product_swipers_product_id` (`product_id`),
  KEY `IX_product_swipers_seller_id` (`seller_id`),
  CONSTRAINT `FK_product_swipers_products_product_id` FOREIGN KEY (`product_id`) REFERENCES `products` (`id`) ON DELETE CASCADE,
  CONSTRAINT `FK_product_swipers_users_seller_id` FOREIGN KEY (`seller_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_swipers`
--

LOCK TABLES `product_swipers` WRITE;
/*!40000 ALTER TABLE `product_swipers` DISABLE KEYS */;
/*!40000 ALTER TABLE `product_swipers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product_videos`
--

DROP TABLE IF EXISTS `product_videos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product_videos` (
  `video_id` int NOT NULL AUTO_INCREMENT,
  `video_url` varchar(500) COLLATE utf8mb4_general_ci NOT NULL,
  `video_title` varchar(200) COLLATE utf8mb4_general_ci NOT NULL,
  `video_description` varchar(500) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `thumbnail_url` varchar(500) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `display_order` int NOT NULL,
  `is_primary` tinyint(1) NOT NULL,
  `is_active` tinyint(1) NOT NULL,
  `duration_seconds` int DEFAULT NULL,
  `file_size` bigint DEFAULT NULL,
  `mime_type` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `video_quality` varchar(20) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `video_format` varchar(10) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `view_count` int NOT NULL,
  `platform_type` int NOT NULL,
  `external_video_id` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `created_at` datetime(6) NOT NULL,
  `updated_at` datetime(6) NOT NULL,
  `uploaded_by` int DEFAULT NULL,
  `Productid` int DEFAULT NULL,
  PRIMARY KEY (`video_id`),
  KEY `IX_product_videos_Productid` (`Productid`),
  KEY `IX_product_videos_uploaded_by` (`uploaded_by`),
  CONSTRAINT `FK_product_videos_products_Productid` FOREIGN KEY (`Productid`) REFERENCES `products` (`id`),
  CONSTRAINT `FK_product_videos_users_uploaded_by` FOREIGN KEY (`uploaded_by`) REFERENCES `users` (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_videos`
--

LOCK TABLES `product_videos` WRITE;
/*!40000 ALTER TABLE `product_videos` DISABLE KEYS */;
/*!40000 ALTER TABLE `product_videos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `products`
--

DROP TABLE IF EXISTS `products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `products` (
  `id` int NOT NULL AUTO_INCREMENT,
  `user_id` int NOT NULL,
  `name` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `description` varchar(300) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '0',
  `price` decimal(18,4) NOT NULL,
  `quantity` int NOT NULL,
  `tags` varchar(200) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `discount_percentage` int NOT NULL,
  `category_id` int NOT NULL,
  `primary_image_id` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `IX_products_category_id` (`category_id`),
  KEY `IX_products_user_id` (`user_id`),
  KEY `IX_products_primary_image_id` (`primary_image_id`) USING BTREE,
  CONSTRAINT `FK_products_categories_category_id` FOREIGN KEY (`category_id`) REFERENCES `categories` (`category_id`) ON DELETE CASCADE,
  CONSTRAINT `FK_products_product_images_product_image_id` FOREIGN KEY (`primary_image_id`) REFERENCES `product_images` (`image_id`),
  CONSTRAINT `FK_products_users_user_id` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
/*!40000 ALTER TABLE `products` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `refunds`
--

DROP TABLE IF EXISTS `refunds`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `refunds` (
  `refund_id` int NOT NULL AUTO_INCREMENT,
  `cancellation_id` int NOT NULL,
  `order_id` int NOT NULL,
  `payment_id` int NOT NULL,
  `customer_id` int NOT NULL,
  `seller_id` int NOT NULL,
  `original_amount` decimal(18,2) NOT NULL,
  `refund_amount` decimal(18,2) NOT NULL,
  `processing_fee` decimal(18,2) NOT NULL,
  `net_refund_amount` decimal(18,2) NOT NULL,
  `reason` varchar(500) COLLATE utf8mb4_general_ci NOT NULL,
  `status` longtext COLLATE utf8mb4_general_ci NOT NULL,
  `refund_method` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `requested_at` datetime(6) NOT NULL,
  `approved_at` datetime(6) DEFAULT NULL,
  `processed_at` datetime(6) DEFAULT NULL,
  `completed_at` datetime(6) DEFAULT NULL,
  `approved_by` int DEFAULT NULL,
  `processed_by` int DEFAULT NULL,
  `transaction_id` varchar(100) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `reference_number` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `bank_account` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `bank_name` varchar(100) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `card_last_four` varchar(4) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `refund_type` varchar(20) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `is_urgent` tinyint(1) NOT NULL,
  `notes` varchar(1000) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `customer_notified` tinyint(1) NOT NULL,
  `seller_notified` tinyint(1) NOT NULL,
  `customer_notified_at` datetime(6) DEFAULT NULL,
  `seller_notified_at` datetime(6) DEFAULT NULL,
  `is_active` tinyint(1) NOT NULL,
  `created_at` datetime(6) NOT NULL,
  `updated_at` datetime(6) NOT NULL,
  PRIMARY KEY (`refund_id`),
  KEY `IX_refunds_approved_by` (`approved_by`),
  KEY `IX_refunds_cancellation_id` (`cancellation_id`),
  KEY `IX_refunds_customer_id` (`customer_id`),
  KEY `IX_refunds_order_id` (`order_id`),
  KEY `IX_refunds_payment_id` (`payment_id`),
  KEY `IX_refunds_processed_by` (`processed_by`),
  KEY `IX_refunds_seller_id` (`seller_id`),
  CONSTRAINT `FK_refunds_cancellations_cancellation_id` FOREIGN KEY (`cancellation_id`) REFERENCES `cancellations` (`cancellation_id`) ON DELETE CASCADE,
  CONSTRAINT `FK_refunds_orders_order_id` FOREIGN KEY (`order_id`) REFERENCES `orders` (`order_id`) ON DELETE CASCADE,
  CONSTRAINT `FK_refunds_payments_payment_id` FOREIGN KEY (`payment_id`) REFERENCES `payments` (`payment_id`) ON DELETE CASCADE,
  CONSTRAINT `FK_refunds_users_approved_by` FOREIGN KEY (`approved_by`) REFERENCES `users` (`user_id`),
  CONSTRAINT `FK_refunds_users_customer_id` FOREIGN KEY (`customer_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE,
  CONSTRAINT `FK_refunds_users_processed_by` FOREIGN KEY (`processed_by`) REFERENCES `users` (`user_id`),
  CONSTRAINT `FK_refunds_users_seller_id` FOREIGN KEY (`seller_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `refunds`
--

LOCK TABLES `refunds` WRITE;
/*!40000 ALTER TABLE `refunds` DISABLE KEYS */;
/*!40000 ALTER TABLE `refunds` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `statuses`
--

DROP TABLE IF EXISTS `statuses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `statuses` (
  `status_id` int NOT NULL AUTO_INCREMENT,
  `status_name` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`status_id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `statuses`
--

LOCK TABLES `statuses` WRITE;
/*!40000 ALTER TABLE `statuses` DISABLE KEYS */;
INSERT INTO `statuses` VALUES (1,'Pending'),(2,'Confirmed'),(3,'Processing'),(4,'Completed'),(5,'Failed'),(6,'Cancelled'),(7,'Refunded'),(8,'Approved'),(9,'Delivered'),(10,'OutForDelivery');
/*!40000 ALTER TABLE `statuses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `user_id` int NOT NULL AUTO_INCREMENT,
  `first_name` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `last_name` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `middle_name` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `email` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `password_hash` longblob NOT NULL,
  `password_salt` longblob NOT NULL,
  `user_role` int NOT NULL,
  `phone_number` varchar(20) COLLATE utf8mb4_general_ci NOT NULL,
  `date_birth` datetime(6) DEFAULT NULL,
  `province` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `city_district` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `mahalla` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `street` varchar(100) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `postal_code` varchar(20) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `latitude` decimal(12,8) NOT NULL,
  `longitude` decimal(18,8) NOT NULL,
  `created_at` datetime(6) NOT NULL,
  `updated_at` datetime(6) DEFAULT NULL,
  `login_status` tinyint(1) NOT NULL,
  `is_active` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`user_id`),
  UNIQUE KEY `IX_Users_Email` (`email`),
  UNIQUE KEY `IX_Users_UserId` (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (2,'Izhorbek','Tursunov',NULL,'user@example.com',_binary '\Õ#\€\"¡i\ﬂE\–e\€ÄHùÚ9Rà¡Q±˙\œA∑˘ï7⁄≠ 9\—\ÿ\‰\≈y\⁄Fn9u<Ñ\Œ\Á\÷2µYX\Ã\◊,',_binary '=\‡Ø\Õ\Á¨PôRNΩ\Ï)õ(¿\«ò_Ù˝O\Á\Ô\'c\∆\ÊÜW\Ô\È\–TNåºN_9ö[{¸`ã¸k:ñVÄøÅ˙¢\ÿ\ÓKh=Îú¢ê#\È\÷b˜\ﬁ\œh±Hã\"˛˙\ƒ\„î»µn5YUÆÖe9é9ˇ9ùñX≠/\ƒ,Bu˚Ñ4€§	',1002,'+998063645295','2025-07-17 23:39:37.470000','string','string','string','string','string',40.54000000,71.01000000,'2025-07-17 23:41:35.193887','2025-07-17 23:41:35.201356',1,1);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-07-18 10:08:01
